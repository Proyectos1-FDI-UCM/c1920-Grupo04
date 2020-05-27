using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableBlocked : MonoBehaviour
{
    public Sprite can_pass, not_pass;
    public Sprite on, off;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<VelBala>())
        {
            if (GetComponent<SpriteRenderer>().sprite == off)
            {
                transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = can_pass;
                GetComponent<SpriteRenderer>().sprite = on;
            }
            else if (GetComponent<SpriteRenderer>().sprite == on)
            {
                transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
                transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = not_pass;
                GetComponent<SpriteRenderer>().sprite = off;
            }
        }
    }
}
