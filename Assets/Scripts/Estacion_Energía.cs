using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion_Energía : MonoBehaviour
{
    private float timer;
    private float cadencia = 0.1f;
    private int bats = 0;

    private void Start()
    {
        this.enabled = false;
    }
    private void Update()
    {
        timer += Time.deltaTime; //Temporizador para limitar el uso de la bala
        if (timer > cadencia)
        {
            GameManager.instance.EnergiaSuma(1);
            timer = 0;
            bats--;
        }

        if (bats <= 0)
        {
            this.enabled = false;
        }

    }
    private void OnTriggerEnter2D(Collider2D jugador)
    {


        if (jugador.GetComponent<PlayerController>())
        {
            bats = GameManager.instance.EnergiaParaSumar();
            this.enabled = true;

            Vector2 posi = new Vector2(jugador.transform.position.x, jugador.transform.position.y + 1); //guardamos la posicion del jugador 1 mas arriba porque da problemas con los pies
            
                                                                                                        //asi no los daria en teoria, sigue haciendolo
                                                                                                        // el problema son los pies como hago que no interactue con los pies?
                                                                                                        //pues una bolsa y al mercadona señora.

            GameManager.instance.GuardaSpawn(posi);
            GameManager.instance.RespawnEnemies();
        }
    }
}
