using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuertePorLuz : MonoBehaviour
{
    //Este script lo tiene el enemigo Espectro, y es el que hace que muera en contacto con la luz

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Interact>() != null)     //Si el trigger tiene componente de interacción (solo el trigger de luz lo tiene)
        {
            AudioManager.instance.PlaySound("morirespectro", "play");
            Destroy(this.gameObject);                       //Se destruye
        }
    }
}
