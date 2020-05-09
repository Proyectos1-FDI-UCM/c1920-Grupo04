using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public GameObject bala;
    public Transform ShotPool;
    public float cadencia;
    private float timer = 2;

    public GameObject sonidoBala;
    
    void Update()
    {
        timer += Time.deltaTime; //Temporizador para limitar el uso de la bala
        if (Input.GetAxis("Fire1") == 1 && GameManager.instance.TieneEnergia() && timer > cadencia && GameManager.instance.Block())
        {
            Instantiate(sonidoBala);
            GameManager.instance.EnergiaSuma(-1);
            Vector2 shotpoint = new Vector2(transform.position.x + 0.25f, transform.position.y - 0.05f);
            GameObject bullet = Instantiate(bala, shotpoint, Quaternion.identity, ShotPool); //Crear la bala
            
            if (gameObject.transform.localScale.x < 0)
                bullet.GetComponent<VelBala>().velocidad *= -1;
            timer = 0;
        }
    }
}
