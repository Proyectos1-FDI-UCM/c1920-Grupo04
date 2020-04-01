using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danyo : MonoBehaviour
{
    public int damage = 1;
    private void OnTriggerEnter2D(Collider2D otro) //el enemigo o objeto que haga daño necesita de otro collider que haga de trigger (podemos hacer que los enemigos no sean bloques si no algo que puedas atravesar como en el mario viceversa...)
    {
        if (otro.gameObject.GetComponent<PlayerController>()) 
        {
            GameManager.instance.RestaVida(damage);
        }
    }
    private void OnCollisionEnter2D(Collision2D otro) // El enemigo seria un bloque con un unico collider, ya sabeis como funciona
    {
        if (otro.gameObject.GetComponent<PlayerController>())
        {
            GameManager.instance.RestaVida(damage);
        }
    }
}
