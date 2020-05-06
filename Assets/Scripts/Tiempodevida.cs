using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiempodevida : MonoBehaviour
{
    public float tiempoDeVida;
    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }
}
