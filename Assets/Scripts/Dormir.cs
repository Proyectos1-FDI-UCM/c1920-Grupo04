using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dormir : MonoBehaviour
    //Este script es usado para deshabilitar al enemigo de goma cuando la luz esté apagada
{
    public Sprite despierto;
    public Sprite dormido;
    SpriteRenderer spriteRenderer;
    VisionEnemigo vision;
    Danyo danyo;
    Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        vision = GetComponent<VisionEnemigo>();
        danyo = GetComponent<Danyo>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (vision.enabled == false && collision.GetComponent<Interact>() != null)   //Si el trigger tiene componente de interacción (solo el trigger de luz lo tiene)
        {
            //Se activa su visión y su daño
            vision.enabled = true;
            danyo.enabled = true;
            spriteRenderer.sprite = despierto;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (vision.enabled = true && collision.GetComponent<Interact>() != null)     //Si el trigger tiene componente de interacción (solo el trigger de luz lo tiene)
        {
            //Se desactiva su visión y su daño
            vision.enabled = false;
            danyo.enabled = false;
            spriteRenderer.sprite = dormido;
        }
    }

}
