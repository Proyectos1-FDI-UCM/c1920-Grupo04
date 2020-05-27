using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableBlocked : MonoBehaviour
{
    public Sprite actived;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<VelBala>())
        {
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            this.gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = actived;
        }
    }
}
