using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    //Este script lo tendrán los enemigos robots (distancia y melee), que son los únicos que dropean objetos

    public GameObject drop;  //game object público que se va a dropear (batertía)

    Disparo scriptDisparo;

    // Start is called before the first frame update
    void Start()
    {
        //guarda en scriptDisparo si este gameObject (robot) tiene o no este script
        scriptDisparo = this.gameObject.GetComponent<Disparo>();
    }

    private void OnDestroy()
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
            Vector3 posicion = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            Instantiate(drop, posicion, Quaternion.identity); //ESTÁ MAL
            cont++;
        }
    }
}
