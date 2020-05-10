using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirse : MonoBehaviour
{
    //public GameObject sonidoDestruir;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        //Instantiate(sonidoDestruir); 
        AudioManager.instance.PlaySound("DBala", "play");

    }
}
