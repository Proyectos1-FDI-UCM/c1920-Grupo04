using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesSpark : MonoBehaviour
{
    //Este script lo tienen los pies de Spark e informan a este mediante el GameManager de si estás o no tocando el suelo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int angle = (int) Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, Vector2.down));
        if (angle == 180 || angle == 129 || angle == 135) //129 y 135 es el ángulo cuando toca un rampa
            GameManager.instance.SueloTocado();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        int angle = (int)Mathf.Abs(Vector2.Angle(collision.GetContact(0).normal, Vector2.down));
        if (angle == 180 || angle == 129 || angle == 135) //129 y 135 es el ángulo cuando toca un rampa
            GameManager.instance.SueloTocado();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameManager.instance.SueloFuera();
    }
}
