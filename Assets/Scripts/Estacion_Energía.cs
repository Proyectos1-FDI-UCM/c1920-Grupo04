using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion_Energía : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D jugador)
    {
        int cantidad = GameManager.instance.EnergiaParaSumar();
        GameManager.instance.EnergiaSuma(cantidad);
        Vector2 posi = new Vector2(jugador.transform.position.x, jugador.transform.position.y);
        GameManager.instance.GuardaSpawn(posi);
    }
}
