using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
    //Este script se usará en los enemigos/muros que se mueren/rompen al ser disparados por el jugador
{
    //Hay que declarar la vida de fomra publica
    public int vida;
    GameObject respo;
    private void Start()
    {
        respo = transform.parent.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<VelBala>() != null)         //si la colisión era una bala
        {
            vida--;
            if (vida <= 0)
            {
                //tengo que cominicarle que se ha muerto al script padre para que leugo lo respawnee
                respo.GetComponent<EnemyRespawn>().IsDead();
                AudioManager.instance.PlaySound("morirenemigo", "play");
                GameManager.instance.SumaPuntuacion(100);
                Destroy(this.gameObject);   //Este objeto (Enemigo/muro) se destruye
            }
        }
    }
}
