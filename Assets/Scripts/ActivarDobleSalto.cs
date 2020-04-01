using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarDobleSalto : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Jugador)
    {

        if (Jugador.gameObject.GetComponent<Disparo>())
        {
            GameManager.instance.ActivarDobleSalto();
            Destroy(this.gameObject);
        }
    }
}
