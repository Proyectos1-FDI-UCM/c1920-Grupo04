using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelBala : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;
    Vector2 velocidadVec;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
    }

    void FixedUpdate()
    {
        velocidadVec = new Vector2(velocidad * transform.right.x, 0f);
        rb.velocity = velocidadVec;
    }

    public void changeDirVel(int dirValue)
    {
        transform.right = new Vector2(transform.right.x * dirValue, transform.right.y);
    }
}
