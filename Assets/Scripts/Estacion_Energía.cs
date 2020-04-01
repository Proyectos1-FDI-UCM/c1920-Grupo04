﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion_Energía : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D jugador)
    {
        int cantidad = GameManager.instance.EnergiaParaSumar();
        GameManager.instance.EnergiaSuma(cantidad);
    }
}
