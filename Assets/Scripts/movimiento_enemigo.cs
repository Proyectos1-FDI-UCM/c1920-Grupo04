using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_enemigo : MonoBehaviour
    //Movimiento enemigo normal, sin estar detectando al jugador 
{
    VisionEnemigo vision;
    float timer;
    Rigidbody2D rb;
    public int vel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vision = GetComponent<VisionEnemigo>();
        timer = 0f;
        
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        rb.velocity = new Vector2(vel, rb.velocity.y);
    }

    private void OnEnable()
    {
        vision.ResetTimer();
        timer = 2f; //cualquier valor > 1 vale, es para que se ejecute el if del onTriggerStay nada más activarse
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Interact>() == null && timer > 1f)
        {
            vel = -vel;
            timer = 0f;
        }
        //solo cambia de dirección si el trigger no tiene interact (porque si no cada vez que entra a una luz gira también, la luz tiene interact)
    }

}

