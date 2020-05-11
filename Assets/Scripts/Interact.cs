using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Sprite LampOn;
    public Sprite LampOff;
    public Sprite Light;
    public bool IsDoor;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    PolygonCollider2D trigger;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trigger = GetComponent<PolygonCollider2D>();
        if (IsDoor == true) {
            boxCollider = GetComponent<BoxCollider2D>();
        }
    }

    
    void Update()
    {
      
    }
    private void OnEnable() {
        AudioManager.instance.PlaySound("interruptor", "play");
        Debug.Log("Activado");
        if (spriteRenderer.sprite == LampOff) {
            spriteRenderer.sprite = LampOn;
        }
        else if (spriteRenderer.sprite == Light && spriteRenderer.enabled == false) {
            spriteRenderer.enabled = true;
            trigger.enabled = true;
        }
        else if (IsDoor == true) {
            boxCollider.enabled = false;
            animator.SetInteger("Open/Close", 1);
        }
    }
    private void OnDisable() {
        AudioManager.instance.PlaySound("interruptor", "play");
        Debug.Log("Desactivado");
        if (spriteRenderer.sprite == LampOn) {
            spriteRenderer.sprite = LampOff;
        }
        else if (spriteRenderer.sprite == Light && spriteRenderer.enabled == true) {
            spriteRenderer.enabled = false;
            trigger.enabled = false;
        }
        else if (IsDoor == true) {
            boxCollider.enabled = true;
            animator.SetInteger("Open/Close", -1);
        }
    }
}
