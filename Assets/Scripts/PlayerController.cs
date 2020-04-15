using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float vel, forceJump;
    public Sprite enCable;
    public Sprite enCamino;
    Rigidbody2D rb;
    float deltaX, deltaY;
    bool salto;
    private Vector2 scale;
    private bool cable = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
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
            rb.gravityScale = 1;
            transform.localScale = scale; //Vuelve al tamaño normal
            this.gameObject.GetComponent<SpriteRenderer>().sprite = enCamino;
            GameObject ChildGameObject = collision.transform.GetChild(0).gameObject;
            gameObject.transform.position = ChildGameObject.transform.position;
        }
    }
    void Update()
    {
        deltaX = Input.GetAxis("Horizontal");
        setScale();
        deltaY = Input.GetAxis("Vertical");
        setScale();
        salto = Input.GetAxis("Jump") == 1;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(deltaX * vel, rb.velocity.y);

        if (!cable)
        {
            if (GameManager.instance.TieneEnergia() && salto && (Mathf.Abs(rb.velocity.y) < 0.01f))

            {
                GameManager.instance.EnergiaSuma(-1);
                rb.AddForce((Vector2.up) * forceJump, ForceMode2D.Impulse);
            }
        }
        else
        {
            rb.velocity = new Vector2(deltaX * vel, deltaY * vel);
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

}

