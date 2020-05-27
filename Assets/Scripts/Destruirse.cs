using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruirse : MonoBehaviour
{
    //public GameObject sonidoDestruir;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //Solo se destruye si no toca al jugador. Si lo toca, se destruirá en el daño
        //Esto es así, porque si no, se destruye antes de producirse el daño
        if (collision.gameObject.GetComponent<PlayerController>() == null)
        {
            Destroy(this.gameObject);
            //Instantiate(sonidoDestruir); 
            AudioManager.instance.PlaySound("DestrBala", "play");
        }


    }
}
