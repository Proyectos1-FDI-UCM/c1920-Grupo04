using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_movil : MonoBehaviour
{
    public GameObject plataforma;
    public Transform inicio, final;
    public float velocidad = 2;

    Vector2 siguientePos;
    void Start()
    {
        siguientePos = inicio.position;
    }

    void Update()
    {
        if (plataforma.transform.position== inicio.position)
        {
            siguientePos = final.position;
        }
        if (plataforma.transform.position== final.position)
        {
            siguientePos = inicio.position;
        }

        plataforma.transform.position = Vector2.MoveTowards(plataforma.transform.position, siguientePos, velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D otro)
    {
        otro.transform.parent = plataforma.transform;
    }
    private void OnCollisionExit2D(Collision2D otro)
    {
        otro.transform.parent = null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(inicio.position, final.position);
    }
}
