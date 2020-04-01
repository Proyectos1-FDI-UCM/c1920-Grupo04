using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AñadeBateria : MonoBehaviour
{
    public int cantidad = 1;
    private void OnCollisionEnter2D(Collision2D Jugador)
    {
        
        if (Jugador.gameObject.GetComponent<Disparo>())
        {
            GameManager.instance.EnergiaSuma(cantidad);
            Destroy(this.gameObject);
        }
    }
}
