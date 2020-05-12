using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEnemigoPerseguir : MonoBehaviour
    //Movimiento enemigo cuando te persigue
{

    Rigidbody2D rb;
    public int vel; //La velocidad cuando te persigue debería de ser mayor que cuando no.
    movimiento_enemigo movNormal;
    int direccion;
    private GameObject player;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //player = GameManager.instance.DevolverJugador().gameObject;
        movNormal = GetComponent<movimiento_enemigo>();
        player = PlayerController.instance.gameObject;
    }
    /*
    private void OnEnable()
    {
        MovEnemigoNormal.enabled = false;
    }
    private void OnDisable()
    {
        MovEnemigoNormal.enabled = true;
    }*/

    private void FixedUpdate()
    {
        if (player.transform.position.x > this.gameObject.transform.position.x)
        {
            direccion = vel;
        }
        else
        {
            direccion = -vel;
        }
        rb.velocity = new Vector2(direccion, rb.velocity.y);
    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        //si el trigger no tiene interact (la luz es la que tiene interact, pero queremos los demás triggers), ha llegado a su límite de movimiento
        if (other.GetComponent<Interact>() == null)
        {
            movNormal.enabled = true;
            this.enabled = false;
        }
        
    }
}
