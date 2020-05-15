using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paracaidas : MonoBehaviour
{
    int layermask;
    float distance;
    Vector2 origin;

    void Start()
    {
        origin = new Vector2(transform.position.x, transform.position.y);
        distance = 0.5f;
        layermask = 1 << 17;
    }

    void FixedUpdate()
    {
        Vector2 actualVel = gameObject.GetComponentInParent<Rigidbody2D>().velocity;
        if (actualVel.y < -5)
            if (Physics2D.Raycast(origin, Vector2.down, distance, layermask))
            {
                Vector2 newVel = new Vector2(actualVel.x, -2);
                gameObject.GetComponentInParent<Rigidbody2D>().velocity = newVel;
                Debug.Log("Paracaidas");
            }
    }
}
