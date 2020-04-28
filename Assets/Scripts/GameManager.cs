using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerController jugadorPC;
    int vida_maxima = 3;
    int vida = 3;
    int Bateria_maxima = 7;
    int Bateria = 7;
    int punt = 0;
    bool mov = true; //true: mov normal  false: mov cable
    Vector2 spawn;
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

    public bool Block()//Del cambio de movimiento
    {
        Debug.Log(mov);
        return mov;
    }

    // Sirve para restar o sumar vida en función del parámetro.
    public void ChangeVida(int cantidad)
    {               

        vida = vida + cantidad;
        if (vida > vida_maxima) vida = vida_maxima; //por si se cuela saes patricio?
                                                    //si llega a 0 pues end game (añadir después)

        if (vida <= 0)
        //Al llegar la vida a 0 hacemos que respawnee el jugador (y la escena)
        {
            jugadorPC.Respawn();
            uimanag.RecuperaVida();
            vida = vida_maxima;
        }

        uimanag.EnseñaVidas(vida);
    }

    public void EnergiaSuma (int cantidad)
    {                               //tmb vale para restar (utilizar dentro de disparo y de salto para consumir bateria)
        //Debug.Log("Bateria maxima: " + Bateria_maxima + "\nBateria antes" + Bateria);
        
            Bateria += cantidad;
            if (Bateria > Bateria_maxima)
            {
                Bateria = Bateria_maxima; //por si se cuela saes patricio?
            }
        
        //Debug.Log("Bateria maxima: " + Bateria_maxima + "\nBateria actual: " + Bateria);
        if (cantidad < 0) uimanag.EnseñaBaterias(Bateria);
        else uimanag.DevuelveEnergia(Bateria);
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
        //Bateria_maxima += cantidad;
        Bateria_maxima = 8; //Esto soluciona el bug que hay para el Hito 2, pero esto no va a ser así al final
        Bateria = Bateria_maxima;
        uimanag.masEnergia(Bateria_maxima);
    }
    public void SumaPuntuacion(int puntos)
    {
        punt += puntos;

        uimanag.EnseñaPunt(punt);
    }

    public void ReconocerJugador(PlayerController player)
    {
        jugadorPC = player;
    }

    /*public PlayerController DevolverJugador()
        //Método que se pasa a los enemigos para que sepan quien es el jugador
    {
        return jugadorPC;
    }*/


    public void ActivarDobleSalto()
    //Activa la habilidad de doble salto al coger el item
    {
        jugadorPC.ActivaDobleSalto(); 
    } 

    public void SueloTocado()
    //Avisa al jugador de que está tocando el suelo
    {
        jugadorPC.HeTocadoSuelo();
    }

    public void SueloFuera()
    //Avisa al jugador de que ya no está en el suelo
    {
        jugadorPC.DejadoDeTocarSuelo();
    }

    public void SetUIManager (UIManager uim)
    //Actualiza un nuevo UIManager (en cada cambio de escena)
    {
        uimanag = uim;
        uimanag.EnseñaVidas(vida);
        uimanag.EnseñaBaterias(Bateria);
        uimanag.EnseñaPunt(punt);
    }
    public void GuardaSpawn(Vector2 posJugador)
    {
        spawn = posJugador;
    }
    public Vector2 EnviaSpawn()
    {
        return spawn;
    }
}