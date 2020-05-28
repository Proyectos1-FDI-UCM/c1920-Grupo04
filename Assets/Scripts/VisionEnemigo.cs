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
    movimiento_enemigo movNormal;
    MovEnemigoPerseguir movEnemigoPerseguir;
    float timer = 0; //contador de tiempo para que el enemigo vuelva a detectarte tras haber llegado a su límite de posición
    Rigidbody2D rb;
    bool estaGirado;
    private GameObject player;
    //int layermask;
    //bool detect = false;

    private void Awake()
    {
        estaGirado = false;
        movNormal = GetComponent<movimiento_enemigo>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //player = GameManager.instance.DevolverJugador().gameObject;
        movEnemigoPerseguir = GetComponent<MovEnemigoPerseguir>();
        movEnemigoPerseguir.enabled = false;
        rb = GetComponent<Rigidbody2D>();
        player = PlayerController.instance.gameObject;
        //layermask = 1 << 8; //La capa 8 es la del player.

    }

    private void OnEnable()
        //Este script (visión) se activa cuando el enemigo de goma deja de estar dormido
    {
        movNormal.enabled = true; //Cuando se despierta se activa por defecto su movNormal
    }

    private void OnDisable()
    //Este script (visión) SOLO se desactiva cuando el enemigo de goma se duerme
    {
        //Cuando se desactiva su visión se desactivan cualquier movimiento activado
        movNormal.enabled = false;
        movEnemigoPerseguir.enabled = false;
        rb.velocity = Vector2.zero;
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
        //if ((Physics2D.Raycast(transform.position, Vector2.left, visionRadio, layermask) || Physics2D.Raycast(transform.position, Vector2.right, visionRadio, layermask)))
        //    detect = true;
        //else
        //    detect = false;

        //Estos ifs se encargan de activar/desactivar movEnemigoPerseguir si el player entra en el campo de visión
        //Pero si el enemigo llega al límite de donde puede llegar, se encarga el propio movEnemigoPerseguir de desactivarse solo.
        if (distancia < visionRadio && !movEnemigoPerseguir.enabled && timer > 2f)//detect
        {
            movEnemigoPerseguir.enabled = true;
            movNormal.enabled = false;
        }
        if (distancia >= visionRadio && movEnemigoPerseguir.enabled)//detect
        {
            movEnemigoPerseguir.enabled = false;
            movNormal.enabled = true;
        }
    }

    public void ResetTimer()
    {
        timer = 0;
    }


}
