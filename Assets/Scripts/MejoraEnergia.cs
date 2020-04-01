using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraEnergia : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D jugador)
    {
        if (jugador.gameObject.GetComponent<Disparo>())
        {
            GameManager.instance.MejoraEnergia(1);
            Destroy(this.gameObject);
        }
    }
}
