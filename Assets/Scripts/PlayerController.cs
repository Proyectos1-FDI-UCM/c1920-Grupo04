﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float vel, velEnCable, forceJump;
    public GameObject cambioMov;
    public static PlayerController instance;
    public Animator animator;
    public bool enElSuelo = false;
    float saltotimer;
    Rigidbody2D rb;
    float deltaX, deltaY;
    bool salto;
    private Vector2 scale;
    private bool cable = false;
    bool puedesDobleSalto = false;
    bool tienesDobleSalto = false;  //Tienes el power-up?
    float contador = 0; //Se utiliza en el salto (tiempo tras salto para usar el doble salto)
    float gravedadIni;
    public bool movRightBlock, movLeftBlock;
    public float velY, velX;
    public float maxFallVelY, maxJumpVel;
    bool parpadeo;
    float parpadeoTimer;
    SpriteRenderer spriteRend;
    public GameObject CD_DSalto;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        
        //Un único GameObject Player (Spark):
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameManager.instance.ReconocerJugador(this);
        spriteRend = GetComponent<SpriteRenderer>();
        gravedadIni = rb.gravityScale;
        parpadeo = false;
        parpadeoTimer = 0f;
    }

    void Update()
    {
        deltaX = Input.GetAxis("Horizontal");
        animator.SetFloat("mov", Mathf.Abs(deltaX));
        setScale();
        deltaY = Input.GetAxis("Vertical");
        setScale();
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up"))
            salto = true;
        else
            salto = false;

        saltotimer += Time.deltaTime;

        if (rb.velocity.y < -maxFallVelY) rb.velocity = new Vector2(rb.velocity.x, -maxFallVelY);
        if (rb.velocity.y > maxJumpVel) rb.velocity = new Vector2(rb.velocity.x, maxJumpVel);
        velY = rb.velocity.y;
        velX = rb.velocity.x;

        //Parpadeo si te quitan vida
        if (parpadeo)
        {
            parpadeoTimer += Time.deltaTime;
            if (parpadeoTimer < 0.15f) spriteRend.enabled = false;
            else if (parpadeoTimer < 0.3f) spriteRend.enabled = true;
            else if (parpadeoTimer < 0.45f) spriteRend.enabled = false;
            else if (parpadeoTimer < 0.6f) spriteRend.enabled = true;
            else if (parpadeoTimer < 0.75f) spriteRend.enabled = false;
            else if (parpadeoTimer < 0.9f)
            {
                spriteRend.enabled = true;
                //Reseteo
                parpadeo = false;
                parpadeoTimer = 0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "cable") //en final por sprite
        {
            CambioAMovCable(collision);
        }
        else if (collision.gameObject.tag == "exit") //en final por sprite
        {
            CambioAMovNormal(collision);
        }        
    }

    private void CambioAMovCable(Collision2D collision)
    {
        //Instantiate(cambioMov);
        cable = true; //Movimiento cable (dejar de saltar)
   
        GameManager.instance.MovCable(); //Avisar dejar de disparar
        rb.gravityScale = 0;
        transform.localScale = scale * new Vector2(0.2f, 0.2f); //Cambiar el tamaño para evitar tener la misma box collider
        animator.SetFloat("enCable", 2);
        GameObject ChildGameObject = collision.transform.GetChild(0).gameObject; //Punto de entrada
        gameObject.transform.position = ChildGameObject.transform.position;
        transform.GetChild(0).gameObject.SetActive(false); //Desactivar pies
        //Cambio de collider del personaje
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void CambioAMovNormal(Collision2D collision)
    {
        //Instantiate(cambioMov);
        //Invoke("DelaySalto", 0.2f); //Movimiento normal (volver a saltar)
        cable = false;     GameManager.instance.MovNormal(); //Volver a disparar
        rb.gravityScale = gravedadIni;
        transform.localScale = scale; //Vuelve al tamaño normal
        animator.SetFloat("enCable", 0);
        if (collision != null) //Es null cuando respawneas
        {
            GameObject ChildGameObject = collision.transform.GetChild(0).gameObject; //Punto de salida
            gameObject.transform.position = ChildGameObject.transform.position;
        }

        transform.GetChild(0).gameObject.SetActive(true); //Activar pies
        //Cambio de collider del personaje       
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
    }
    void DelaySalto()
    {
        cable = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int angle = (int)Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, Vector2.right));
        if (angle <= 180 && angle >= 130)
            movRightBlock = true;
        else
            movRightBlock = false;
        if (angle >= 0 && angle <= 40)
            movLeftBlock = true;
        else
            movLeftBlock = false;
        //Debug.Log(angle);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        movLeftBlock = false;
        movRightBlock = false;
    }

    public void ActivaDobleSalto()
    //Método llamado por el GameManager cuando coges el power-up de doble salto
    {
        tienesDobleSalto = true;
        enElSuelo = true; //Esto no debería de estar aquí, pero soluciona el bug de que al coger el doble salto no podías saltar
        CD_DSalto.SetActive(true);
    }

    public void Nivel2Inicializacion()
    {
        tienesDobleSalto = true;
        CD_DSalto.SetActive(true);
        GameManager.instance.SetDeathScreen();
    }

    public void HeTocadoSuelo()
    //Llamado desde los pies a través del GameManager
    {
       
        puedesDobleSalto = tienesDobleSalto;    //Se podrá usar de nuevo el doble salto (si lo tienes)
        enElSuelo = true;                       //Está en el suelo (puede saltar sin gastar el doble salto)
        if (saltotimer >= 0.1f)
        {
            animator.SetFloat("jump", 0f); //animación salto acaba
        }
    }

    public void DejadoDeTocarSuelo()
    {
        enElSuelo = false;                      //No se puede saltar, a no ser que tengas el doble
        GameManager.instance.freeDSalto();
    }

    void FixedUpdate()
    {
        contador += Time.fixedDeltaTime; //Cuenta el tiempo desde el último salto normal
        //Sirve para dejar un tiempo entre un salto y el doble salto, ya que si este contador te hace los dos a la vez solo pulsando una sola vez

        if (!cable) //Si no estás en cable
        {
            // Permite el movimiento lateral a la derecha y viceversa
            if (deltaX > 0 && !movRightBlock)
                rb.velocity = new Vector2(deltaX * vel, rb.velocity.y); //Movimiento normal
            else if (deltaX < 0 && !movLeftBlock)
                rb.velocity = new Vector2(deltaX * vel, rb.velocity.y); //Movimiento normal

            //SALTO
            if (salto && GameManager.instance.TieneEnergia())   //Si tienes energía y pulsas salto
            {
               
                //Hay dos posibilidades, o salto normal o el doble.

                if (enElSuelo)   //Si estás en el suelo
                {
                    saltotimer = 0;
                    animator.SetFloat("jump", 2f);//animación salto

                    //saltas
                    AudioManager.instance.PlaySound("jump", "play");
                    GameManager.instance.EnergiaSuma(-1);
                    rb.AddForce((Vector2.up) * forceJump, ForceMode2D.Impulse);
                    contador = 0;   //reseteas el contador para realizar el doble salto
                    salto = false;
                    
                }

                else if (puedesDobleSalto && contador > 0.25f && GameManager.instance.puedeDSalto())  //Si no estás en el suelo, y puedes realizar el doble salto
                {
                    saltotimer = 0;
                    animator.SetFloat("jump", 2f);//animación salto

                    AudioManager.instance.PlaySound("jump", "play");
                    rb.velocity = new Vector2(deltaX * vel, 0f); //Se pierde la velocidad que llevases vertical para el siguiente impulso
                    //(en el salto normal no es perder la velocidad vertical porque al estar en el suelo es 0)
                    
                    //saltas(doble)
                    GameManager.instance.EnergiaSuma(-1);
                    rb.AddForce((Vector2.up) * forceJump, ForceMode2D.Impulse);
                    puedesDobleSalto = false;   //pierdes la capacidad del doble salto
                    salto = false;
                    GameManager.instance.blockDSalto();
                }                
            }
        }
        else        //Si estás en cable
        {
            rb.velocity = new Vector2(deltaX * velEnCable, deltaY * velEnCable);  //Movimiento cable
            
        }
    }
    // Configura la escala de Spark. Hacia dónde mira.
    private void setScale()
    {
        if (deltaX < 0 && !cable)
            transform.localScale = scale * new Vector2(-1, 1);
        else if (deltaX > 0 && !cable)
            transform.localScale = scale;
    }

    public void Respawn()
    {
        Vector2 spawn = GameManager.instance.EnviaSpawn();
        transform.position = spawn;
        if (cable) CambioAMovNormal(null);
        GameManager.instance.RespawnEnemies();
        //Por si acaso muriese en una plataforma
    }

    public void Parpadea()
        //Método llamado al perder vida para que Spark empiece a parpadear
    {
        parpadeo = true;
    }
}

