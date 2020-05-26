using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySound("Coin", "play");
            GameManager.instance.SumaPuntuacion(50);
        }
        
    }
}
