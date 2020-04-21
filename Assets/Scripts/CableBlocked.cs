using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableBlocked : MonoBehaviour
{
    public Material actived;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Disparo>() || collision.gameObject.GetComponent<VelBala>())
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            gameObject.GetComponent<MeshRenderer>().material = actived;
        }
    }
}
