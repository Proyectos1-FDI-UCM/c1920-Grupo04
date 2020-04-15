using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerController jugadorPC;
    int vida_maxima = 5;
    int vida = 3;
    int Bateria_maxima = 7;
    int Bateria = 7;
    int punt = 0;
    bool mov = true; //true: mov normal  false: mov cable
    UIManager uimanag;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CambioMov()
    {
        mov = !mov;
    }

    public bool Block()
    {
        return mov;
    }
    public void RestaVida(int cantidad)
    {               //Que tmb vale para sumarle
        
            vida = vida - cantidad;
            if (vida > vida_maxima) vida = vida_maxima; //por si se cuela saes patricio?
            //si llega a 0 pues end game (añadir después)
        
        Debug.Log("vida: " + vida);
        if (vida < 0) Debug.Log("tas muerto illo");

        
        uimanag.EnseñaVidas(vida, vida_maxima);
    }

    public void EnergiaSuma (int cantidad)
    {                               //tmb vale para restar (utilizar dentro de disparo y de salto para consumir bateria)
        Debug.Log("Bateria maxima: " + Bateria_maxima + "\nBateria antes" + Bateria);
        
            Bateria = Bateria + cantidad;
            if (Bateria > Bateria_maxima)
            {
                Bateria = Bateria_maxima; //por si se cuela saes patricio?
            }
        
        Debug.Log("Bateria maxima: " + Bateria_maxima + "\nBateria actual: " + Bateria);

        uimanag.EnseñaBaterias(Bateria, Bateria_maxima);
    }
    public int EnergiaParaSumar() //Calcula la diferencia de energía
    {
        return Bateria_maxima - Bateria;
    }
    public bool TieneEnergia()
    {
        return (Bateria > 0);
    }

    public void MejoraEnergia (int cantidad) 
    {
        Debug.Log("Bateria maxima antes: " + Bateria_maxima + "\nBateria actual: " + Bateria);
        Bateria_maxima = Bateria_maxima + cantidad;
        // Queremos la mejora tmb recargue? 
        //EnergiaSuma(EnergiaParaSumar());        
        Debug.Log("Bateria maxima ahora: " + Bateria_maxima + "\nBateria actual: " + Bateria);

        uimanag.EnseñaBaterias(Bateria, Bateria_maxima);
    }
    public void SumaPuntuacion(int puntos)
    {
        punt += puntos;
        Debug.Log("Puntuacion: " + punt);

        uimanag.EnseñaPunt(punt);
    }

    public void ReconocerJugador(PlayerController player)
    {
        jugadorPC = player;
    }


    public void ActivarDobleSalto()
    {
        Debug.Log("Doble salto adquirido");
        jugadorPC.ActivaDobleSalto(); 
    } 

    public void SetUIManager (UIManager uim)
    //Actualiza un nuevo UIManager (en cada cambio de escena)
    {
        uimanag = uim;
        uimanag.EnseñaVidas(vida, vida_maxima);
        uimanag.EnseñaBaterias(Bateria, Bateria_maxima);
        uimanag.EnseñaPunt(punt);
    }
}