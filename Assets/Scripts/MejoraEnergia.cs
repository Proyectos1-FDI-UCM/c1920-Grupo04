using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraEnergia : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D jugador)
    {
        if (jugador.gameObject.GetComponent<PlayerController>() != null)
        {
            AudioManager.instance.PlaySound("PowerUp", "play");
            GameManager.instance.MejoraEnergia();
            Destroy(this.gameObject);
        }
    }
}
