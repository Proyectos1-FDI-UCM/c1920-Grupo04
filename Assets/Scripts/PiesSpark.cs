using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesSpark : MonoBehaviour
{
    //Este script lo tienen los pies de Spark e informan a este mediante el GameManager de si estás o no tocando el suelo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int angle = (int) Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, Vector2.down));
        if (angle <= 180 && angle >= 125) // Valores continuos en vez de estrictos
            GameManager.instance.SueloTocado();
        //Debug.Log(angle);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int angle = (int)Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, Vector2.down));
        if (angle <= 180 && angle >= 125) // Valores continuos en vez de estrictos
            GameManager.instance.SueloTocado();
        //Debug.Log(angle);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameManager.instance.SueloFuera();
    }
}
