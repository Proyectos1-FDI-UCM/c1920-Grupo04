using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paracaidas : MonoBehaviour
{
    int layermask;
    float distance;

    void Start()
    {
        distance = 0.5f;
        layermask = 1 << 17; // Capa de las plataformas de la escena
    }

    void FixedUpdate()
    {
        Vector2 actualVel = gameObject.GetComponentInParent<Rigidbody2D>().velocity;
        if (actualVel.y < -5)
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, distance, layermask))
            {
                Vector2 newVel = new Vector2(actualVel.x, -4);
                gameObject.GetComponentInParent<Rigidbody2D>().velocity = newVel;
                //Debug.Log("Paracaidas");
            }
        }
    }
}
