using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRobot : MonoBehaviour
{
    public Transform ShotPool;
    public GameObject bullet;
    public float distance;
    public float CD;
    bool shotOnCD;
    int layermask, dirValue;
    Vector2 origin;

    // Start is called before the first frame update
    void Start()
    {
        layermask = 1 << 8; //La capa 8 es la del player.        
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
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            dirValue = 1;
            if (!shotOnCD) shootPlayer();
            Debug.Log("DERECHA");
        }
        else if (Physics2D.Raycast(origin, Vector2.left, distance, layermask))
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            dirValue = -1;
            if (!shotOnCD) shootPlayer();
            Debug.Log("IZQUIERDA");
        }
    }

    void shootPlayer()
    {
        //Calcula el punto de salida
        Vector2 shotpoint = new Vector2(transform.position.x, transform.position.y);
        //Genera la bala
        GameObject newBullet = Instantiate(bullet, shotpoint, Quaternion.identity, ShotPool);
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
}
