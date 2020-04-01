using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector2 move;
    public float speed;
    Rigidbody2D rbpala;
    BoxCollider2D cld;

    void Start() {
        rbpala = GetComponent<Rigidbody2D>();
        //consigo el boxcollider para saber el ancho de la pala
        cld = GetComponent<BoxCollider2D>();
    }

    void Update() {
        //coje el imput de las flechas del teclado y de "a" y "d" para mover la pala 
        float delta = Input.GetAxis("Horizontal");
        move = new Vector2(delta, 0);

    }

    private void FixedUpdate() {
        //usar velocity para mover la pala en cualquier direccion sin inercia
        if (rbpala != null) {
            rbpala.velocity = move * speed;
        }
    }
    
}
