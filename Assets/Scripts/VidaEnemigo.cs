using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
    //Este script se usará en los enemigos/muros que se mueren/rompen al ser disparados por el jugador
{
    //Hay que declarar la vida de fomra publica
    public int vida;
    GameObject respo;
    public int puntuacion = 100;
    //Utiliza el metodo de Drop
    public GameObject drop;  //game object público que se va a dropear (batería)
    DisparoRobot scriptDisparo;
    private void Start()
    {
    
        //guarda en scriptDisparo si este gameObject (robot) tiene o no este script
        scriptDisparo = this.gameObject.GetComponent<DisparoRobot>();
        respo = transform.parent.gameObject;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        VelBala colisionante = collision.gameObject.GetComponent<VelBala>();
        if (colisionante != null && !colisionante.IsEnemy())         //si la colisión era una bala
        {
            vida--;
            if (vida <= 0)
            {
                //tengo que cominicarle que se ha muerto al script padre para que leugo lo respawnee
                respo.GetComponent<EnemyRespawn>().IsDead();
                AudioManager.instance.PlaySound("morirenemigo", "play");
                GameManager.instance.SumaPuntuacion(puntuacion);
                if (drop != null && GameManager.instance != null)
                {
                    int numDrop;
                    //La manera de saber que robot se hace mirando si tiene o no el scriptDisparo
                    if (scriptDisparo != null)          //si tiene scriptDisparo es un robot a distancia
                    {
                        numDrop = Random.Range(1, 3);   //por lo que dropea entre 1 y 2 (3 sin incluir)
                    }
                    else                                //si no tiene scriptDisparo no es un robot a distancia
                    {                                   //(es un robot a melee)
                        numDrop = Random.Range(0, 2);   //por lo que dropea entre 0 y 1 (2 sin incluir)
                    }

                    //DROPEO
                    int cont = 0;
                    while (cont < numDrop)
                    {
                        Vector3 posicion = new Vector2(this.transform.position.x, this.transform.position.y);
                        Instantiate(drop, posicion, Quaternion.identity); //ESTÁ MAL
                        cont++;
                    }
                }
                Destroy(this.gameObject);   //Este objeto (Enemigo/muro) se destruye
            }
        }
    }
}
