using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : MonoBehaviour
    //Este script es usado para deshabilitar al enemigo de goma cuando la luz esté apagada
{
    public Sprite despierto;
    public Sprite dormido;
    SpriteRenderer spriteRenderer;
    movimiento_enemigo mov;
    Danyo danyo;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mov = GetComponent<movimiento_enemigo>();
        danyo = GetComponent<Danyo>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Interact>() != null && mov.enabled == false)   //Si el trigger tiene componente de interacción (solo el trigger de luz lo tiene)
        {
            //Se activa su movimiento y su daño
            mov.enabled = true;
            danyo.enabled = true;
            spriteRenderer.sprite = despierto;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Interact>() != null)     //Si el trigger tiene componente de interacción (solo el trigger de luz lo tiene)
        {
            //Se desactiva su movimiento y su daño
            mov.enabled = false;
            danyo.enabled = false;
            spriteRenderer.sprite = dormido;
        }
    }

}
