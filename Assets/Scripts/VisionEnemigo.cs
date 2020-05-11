using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este este script esta pensado de forma que compara las posiciones y
/// según la distancia le persigue o no, pero no tiene en cuenta si están en
/// la misma horizontal.
/// </summary>
public class VisionEnemigo : MonoBehaviour
{
    //Script que detecta si el jugador está en el campo de visión de un enemigo, y activa el movimiento correspondiente de este enemigo
    public float visionRadio;
    MovEnemigoPerseguir movEnemigoPerseguir;
    float timer = 0; //contador de tiempo para que el enemigo vuelva a detectarte tras haber llegado a su límite de posición
    Rigidbody2D rb;
    bool estaGirado;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //player = GameManager.instance.DevolverJugador().gameObject;
        movEnemigoPerseguir = GetComponent<MovEnemigoPerseguir>();
        movEnemigoPerseguir.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        estaGirado = false;
        player = PlayerController.instance.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotación del sprite (lo pongo en este script porque es el que siempre está activo)
        if (estaGirado && rb.velocity.x > 0)
        {
            estaGirado = false;
            transform.Rotate(0, 180, 0);
        }
        else if (!estaGirado && rb.velocity.x <= 0)
        {
            estaGirado = true;
            transform.Rotate(0, 180, 0);
        }

        //Distancia entre enemigo y jugador
        float distancia = Vector2.Distance(player.transform.position, transform.position);
        timer += Time.fixedDeltaTime;

        //Al activarse y desactivarse movEnemigoPerseguir, se activa/desactiva el movNormal con OnEnable/Disable en MovEnemigoPerseguir

        //Estos ifs se encargan de activar/desactivar movEnemigoPerseguir si el player entra en el campo de visión
        //Pero si el enemigo llega al límite de donde puede llegar, se encarga el propio movEnemigoPerseguir de desactivarse solo.
        if (distancia < visionRadio && !movEnemigoPerseguir.enabled && timer > 2f)
        {
            movEnemigoPerseguir.enabled = true;

        }
        if (distancia >= visionRadio && movEnemigoPerseguir.enabled)
        {
            movEnemigoPerseguir.enabled = false;
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }


}
