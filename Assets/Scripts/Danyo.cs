using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danyo : MonoBehaviour
{
    public int damage = 1;
    private float CD, time;
    VelBala bala;
    private void Start()
    {
        bala = GetComponent<VelBala>();
        if (bala != null) CD = 0f; //Si es una bala, no tiene cooldown
        else CD = 1f;
        time = 0;
    }

    private void OnTriggerEnter2D(Collider2D otro) //el enemigo o objeto que haga daño necesita de otro collider que haga de trigger (podemos hacer que los enemigos no sean bloques si no algo que puedas atravesar como en el mario viceversa...)
    {
        if (isActiveAndEnabled && otro.gameObject.GetComponent<PlayerController>()) 
        {
            if (Time.time - time >= CD)
            {
                GameManager.instance.ChangeVida(-damage);
                time = Time.time;
            }
            if (bala != null) Destroy(this.gameObject);//Si es una bala, se destruye
        }
    }
    private void OnCollisionEnter2D(Collision2D otro) // El enemigo seria un bloque con un unico collider, ya sabeis como funciona
    {
        if (isActiveAndEnabled && otro.gameObject.GetComponent<PlayerController>())
        {
            if (Time.time - time >= CD)
            {
                GameManager.instance.ChangeVida(-damage);
                time = Time.time;
            }
            if (bala != null) Destroy(this.gameObject);//Si es una bala, se destruye
        }
    }
}
