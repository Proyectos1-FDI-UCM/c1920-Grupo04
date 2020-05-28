using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRobot : MonoBehaviour
{
    public GameObject bullet;
    public float distance;
    public float CD;
    bool shotOnCD;
    int layermask, dirValue;
    Vector2 origin;
    private Transform shotPool;
    VisionEnemigo vision;
    Animator anim;
    bool darseVuelta;

    // Start is called before the first frame update
    void Start()
    {
        layermask = 1 << 8; //La capa 8 es la del player.  
        shotPool = ShotPool.instance.transform;
        vision = GetComponent<VisionEnemigo>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LocalizaAlJugador();
    }


    /// <summary>
    /// Lanza un rayo virtual en la horizontal con la distancia definida como longitud
    /// máxima, hacia ambos lados, si encuentra al jugador, dispara hacia donde se encuentre.
    /// </summary>
    void LocalizaAlJugador()
    {
        origin = new Vector2(transform.position.x, transform.position.y);
        //Localiza a que lado está el jugador y si está dentro del rango
        if (Physics2D.Raycast(origin, Vector2.right, distance, layermask))
        {
            //Cambia el lado al que mira el robot
            dirValue = 1;
            if (!shotOnCD && (int)transform.rotation.y == 0) shootPlayer();
            Debug.Log("DERECHA");
        }
        else if (Physics2D.Raycast(origin, Vector2.left, distance, layermask))
        {
            dirValue = -1;
            if (!shotOnCD && (int)transform.rotation.y - 180 < 1) shootPlayer();
            Debug.Log("IZQUIERDA");
        }
    }

    void shootPlayer()
    {
        //Deja de mover al robot
        vision.enabled = false; //Al desactivarse la visión, se desactiva cualquier movimiento
        anim.enabled = false;
        Invoke("Movimiento", 1f);

        //Si estás a la izquierda y el robot estaba mirando a la derecha, o estás a la derecha y el robot estaba mirando a la izquierda
        if ((dirValue == -1 && (int) transform.rotation.y == 0) || (dirValue == 1 && (int) transform.rotation.y == 1))
        {
            //Se le da la vuelta
            transform.Rotate(0, 180, 0);
            darseVuelta = true;
        }
        else darseVuelta = false;

        //Calcula el punto de salida
        Vector2 shotpoint = new Vector2(transform.position.x, transform.position.y);
        //Genera la bala
        GameObject newBullet = Instantiate(bullet, shotpoint, Quaternion.identity, shotPool);
        AudioManager.instance.PlaySound("DispRoboRanged", "play");
        //Velocidad y horientación de la bala
        newBullet.GetComponent<VelBala>().changeDirVel(dirValue);
        //newBullet.transform.localScale = new Vector2(dirValue * Mathf.Abs(newBullet.transform.localScale.x), newBullet.transform.localScale.y);
        //CoolDown
        shotOnCD = true;
        Invoke("resetCD", CD);
    }


    void resetCD()
    {
        shotOnCD = false;
    }

    void Movimiento()
    {
        vision.enabled = true;
        anim.enabled = true;
        if (darseVuelta) transform.Rotate(0, 180, 0);
    }
}
