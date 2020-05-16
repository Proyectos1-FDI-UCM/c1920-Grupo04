using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion_Energía : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D jugador)
    {
        if (jugador.GetComponent<PlayerController>())
        {
            int cantidad = GameManager.instance.EnergiaParaSumar();
            GameManager.instance.EnergiaSuma(cantidad);
            Vector2 posi = new Vector2(jugador.transform.position.x, jugador.transform.position.y); //guardamos la posicion del jugador 1 mas arriba porque da problemas con los pies
            
                                                                                                        //asi no los daria en teoria, sigue haciendolo
                                                                                                        // el problema son los pies como hago que no interactue con los pies?
                                                                                                        //pues una bolsa y al mercadona señora, estaria gucci tener las capas de colisiones ehh?

            GameManager.instance.GuardaSpawn(posi);
            GameManager.instance.RespawnEnemies();

        }
    }
}
