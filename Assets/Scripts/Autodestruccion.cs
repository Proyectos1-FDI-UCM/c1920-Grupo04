using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestruccion : MonoBehaviour
{
    public float segdevida;
    private float timer;

    void Awake()
    {
        timer = 0;
    }
    void Update()
    {
        timer += Time.deltaTime; //Temporizador para limitar el uso de la bala
        if (timer > segdevida)
        {
            Destroy(this.gameObject);
        }
    }
}
