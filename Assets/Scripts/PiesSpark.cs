﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesSpark : MonoBehaviour
{
    //Este script lo tienen los pies de Spark e informan a este mediante el GameManager de si estás o no tocando el suelo

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("suelo"))
            //GameManager.instance.SueloTocado();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("suelo"))
            //GameManager.instance.SueloFuera();
    }
}
