using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraEnergia : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D jugador)
    {
        bool yaEsta = false;
        if (jugador.gameObject.GetComponent<PlayerController>() != null && !yaEsta)
        {
            yaEsta = true;
            GameManager.instance.MejoraEnergia(1);
            Destroy(this.gameObject);
        }
    }
}
