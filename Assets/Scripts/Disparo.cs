using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    public GameObject spawn;
    public float cadencia;
    private float timer = 2;
    
    void Update()
    {
        timer += Time.deltaTime; //Temporizador para limitar el uso de la bala
        if (Input.GetAxis("Fire1") == 1 && GameManager.instance.TieneEnergia() && timer > cadencia && GameManager.instance.Block())
        {
            GameManager.instance.EnergiaSuma(-1);
            GameObject bullet = Instantiate(bala, spawn.transform.position, Quaternion.identity); //Crear la bala
            
            if (gameObject.transform.localScale.x < 0)
                bullet.GetComponent<VelBala>().velocidad *= -1;
            timer = 0;
        }
    }
}
