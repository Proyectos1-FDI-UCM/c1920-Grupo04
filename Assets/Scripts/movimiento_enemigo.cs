using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento_enemigo : MonoBehaviour
{

    Rigidbody2D rb;
    public int vel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(vel, rb.velocity.y);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Interact>() == null)
        {
            vel = -vel;
            transform.Rotate(0, 180, 0);
        }
        //solo cambia de dirección si el trigger no tiene interact (porque si no cada vez que entra a una luz gira también, la luz tiene interact)
    }

}

