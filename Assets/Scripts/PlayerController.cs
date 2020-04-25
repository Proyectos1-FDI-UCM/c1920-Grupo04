﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float vel, forceJump;
    public Sprite enCable;
    public Sprite enCamino;
    public Animation idle;
    public Animation run;
    Animator animator;
    Rigidbody2D rb;
    float deltaX, deltaY;
    bool salto;
    private Vector2 scale;
    private bool cable = false;
    bool enElSuelo = false;
    bool puedesDobleSalto = false;
    bool tienesDobleSalto = false;  //Tienes el power-up?
    float contador = 0; //Se utiliza en el salto (tiempo tras salto para usar el doble salto)
    float gravedadIni;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
        
    }

    void Start()
    {
        GameManager.instance.ReconocerJugador(this);
        gravedadIni = rb.gravityScale;
    }

    void Update()
    {
        deltaX = Input.GetAxis("Horizontal");
        setScale();
        deltaY = Input.GetAxis("Vertical");
        setScale();
        salto = Input.GetAxis("Jump") == 1;
        Debug.Log(enElSuelo);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "cable") //en final por sprite
        {
            cable = true;
            GameManager.instance.CambioMov(); //Avisar dejar de disparar y saltar
            rb.gravityScale = 0;
            transform.localScale = scale * new Vector2(0.5f, 0.5f); //Cambiar el tamaño para evitar tener la misma box collider
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enCable;
            GameObject ChildGameObject = collision.transform.GetChild(0).gameObject;
            gameObject.transform.position = ChildGameObject.transform.position;
        }
        else if (collision.gameObject.tag == "exit") //en final por sprite
        {
            cable = false;
            GameManager.instance.CambioMov();
            rb.gravityScale = 3;
            transform.localScale = scale; //Vuelve al tamaño normal
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enCamino;
            GameObject ChildGameObject = collision.transform.GetChild(0).gameObject;
            gameObject.transform.position = ChildGameObject.transform.position;
        }
    }

    public void ActivaDobleSalto()
    //Método llamado por el GameManager cuando coges el power-up de doble salto
    {
        tienesDobleSalto = true;
    }

    public void HeTocadoSuelo()
    //Llamado desde los pies a través del GameManager
    {
        puedesDobleSalto = tienesDobleSalto;    //Se podrá usar de nuevo el doble salto (si lo tienes)
        enElSuelo = true;                       //Está en el suelo (puede saltar sin gastar el doble salto)
    }

    public void DejadoDeTocarSuelo()
    {
        enElSuelo = false;                      //No se puede saltar, a no ser que tengas el doble
    }

    void FixedUpdate()
    {
        contador += Time.fixedDeltaTime; //Cuenta el tiempo desde el último salto normal
        //Sirve para dejar un tiempo entre un salto y el doble salto, ya que si este contador te hace los dos a la vez solo pulsando una sola vez

        if (!cable) //Si no estás en cable
        {
            rb.velocity = new Vector2(deltaX * vel, rb.velocity.y); //Movimiento normal

            //SALTO
            if (GameManager.instance.TieneEnergia() && salto && contador > 0.5f)   //Si tienes energía y pulsas salto
            {
                //Hay dos posibilidades, o salto normal o el doble.

                if (enElSuelo)   //Si estás en el suelo
                {
                    //saltas
                    GameManager.instance.EnergiaSuma(-1);
                    rb.AddForce((Vector2.up) * forceJump, ForceMode2D.Impulse);
                    contador = 0;   //reseteas el contador para realizar el doble salto
                }

                else if (puedesDobleSalto)  //Si no estás en el suelo, y puedes realizar el doble salto
                {
                    rb.velocity = new Vector2(deltaX * vel, 0f); //Se pierde la velocidad que llevases vertical para el siguiente impulso
                    //(en el salto normal no es perder la velocidad vertical porque al estar en el suelo es 0)
                    
                    //saltas(doble)
                    GameManager.instance.EnergiaSuma(-1);
                    rb.AddForce((Vector2.up) * forceJump, ForceMode2D.Impulse);
                    puedesDobleSalto = false;   //pierdes la capacidad del doble salto
                }
                
            }
        }
        else        //Si estás en cable
        {
            rb.velocity = new Vector2(deltaX * vel, deltaY * vel);  //Movimineto cable
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
        //Por si acaso muriese en una plataforma
    }
}

