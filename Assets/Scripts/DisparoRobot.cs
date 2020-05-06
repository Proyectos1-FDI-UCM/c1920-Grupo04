using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoRobot : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bullet;
    public float distance;
    public float CD;
    bool shotOnCD;
    int layermask, dirValue;
    Vector2 direction, origin;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn.position = transform.position;
        //player = GameManager.instance.GetPlayer();
        layermask = 1 << 8;
        origin = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("AWAKE");
    }

    // Update is called once per frame
    void Update()
    {
        LocalizaAlJugador();
        Debug.Log("buscando...");
    }

    /// <summary>
    /// Lanza un rayo virtual en la horizontal con la distancia definida como longitud
    /// máxima, hacia ambos lados, si encuentra al jugador, dispara hacia donde se encuentre.
    /// </summary>
    void LocalizaAlJugador()
    {
        
        if (Physics2D.Raycast(origin, Vector2.right, distance, layermask))
        {
            //Cambia el lado al que mira el robot
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            //direction = Vector2.right;
            dirValue = 1;
            if (!shotOnCD) shootPlayer();
            Debug.Log("DERECHA");
        }
        else if (Physics2D.Raycast(origin, Vector2.left, distance, layermask))
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            //direction = Vector2.left;
            dirValue = -1;
            if (!shotOnCD) shootPlayer();
            Debug.Log("IZQUIERDA");
        }
    }

    void shootPlayer()
    {
        GameObject newBullet = Instantiate(bullet, bulletSpawn.position, Quaternion.identity, bulletSpawn);
        newBullet.GetComponent<VelBala>().changeDirVel(dirValue);
        shotOnCD = true;
        Invoke("resetCD", CD);
    }

    void resetCD()
    {
        shotOnCD = false;
    }
}
