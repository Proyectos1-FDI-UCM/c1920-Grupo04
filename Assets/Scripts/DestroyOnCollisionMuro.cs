using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionMuro : MonoBehaviour
    //Este script se usará en los muros que se rompen al ser disparados por el jugador
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //guardo si la colisión tenía un nombreScriptBala o no para saber si es una bala
        VelBala scriptBala = collision.gameObject.GetComponent<VelBala>();
        Danyo scriptDanyo = collision.gameObject.GetComponent<Danyo>();

        if (scriptBala != null && scriptDanyo == null)         //si la colisión era una bala y no era enemigo
        {
            Destroy(this.gameObject);   //Este objeto (muro) se destruye
        }

    }
}
