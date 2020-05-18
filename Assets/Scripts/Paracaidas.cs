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
        layermask = 1 << 17; //Hace una operación.
    }

    void FixedUpdate()
    {
        Vector2 actualVel = gameObject.GetComponentInParent<Rigidbody2D>().velocity;
        if (Physics2D.Raycast(transform.position, Vector2.down, distance, layermask))
        {
            GameManager.instance.SueloTocado();
            if (actualVel.y <= -5)
            {
                Vector2 newVel = new Vector2(actualVel.x, -4);
                gameObject.GetComponentInParent<Rigidbody2D>().velocity = newVel;                
                Debug.Log("Paracaidas");
            }
        }
        else
            GameManager.instance.SueloFuera();
    }

    public bool CheckMove(Vector2 direction, bool check)
    {
        //bool check;
        float distance = 1f;
        int layermask = 1 << 17; //Hace una operación.
        if (Physics2D.Raycast(transform.position, direction, distance, layermask))
            check = true;
        return check;
    }
}
