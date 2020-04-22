using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    PlayerController jugadorPC;
    int punt = 0;
    bool mov = true; // (true: mov normal | false: mov cable)
    Vector2 spawn;
    UIManager uimanag;
    //int vida = 3;
    //int Bateria = 7;
    //int vida_maxima = 3;
    //int Bateria_maxima = 7;

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

    // antiguo: sumaVida
    public void ChangeVida(int cantidad)
    { //Que tmb vale para sumarle
        
            vida = vida - cantidad;
            if (vida > vida_maxima) vida = vida_maxima; //por si se cuela saes patricio?
            //si llega a 0 pues end game (añadir después)
        
        Debug.Log("vida: " + vida);
        if (vida < 0)
            //Al llegar la vida a 0 hacemos que respawnee el jugador (y la escena)
        {
            jugadorPC.Respawn();
            vida = vida_maxima;
        }

        
        uimanag.EnseñaVidas(vida);
    }

    // antiguo: EnergiaSuma
    public void ChangeEnergia (int cantidad)
    { //tmb vale para restar (utilizar dentro de disparo y de salto para consumir bateria)
        Debug.Log("Bateria maxima: " + uimanag.GetMaxBat() + "\n     Bateria antes: " + Bateria);

        uimanag.SetBats(cantidad);
            if (uimanag.GetBateries() > uimanag.GetMaxBat())
            {
                Bateria = Bateria_maxima; //por si se cuela saes patricio?
            }
        
        Debug.Log("Bateria maxima: " + Bateria_maxima + "\n     Bateria actual: " + Bateria);
        if (cantidad < 0) uimanag.EnseñaBaterias(Bateria);
        else uimanag.DevuelveEnergia(Bateria);
    }
    public int EnergiaParaSumar() // Calcula la diferencia de energía
    {
        return Bateria_maxima - Bateria;
    }

    public bool TieneEnergia()
    {
        return (uimanag.GetBateries() > 0);
    }

    public void MejoraEnergia (int cantidad) 
    {
        uimanag.añadeBaterias(cantidad);
    }

    public void SumaPuntuacion(int puntos)
    {
        punt += puntos;
        uimanag.MuestraPunt(punt);
    }

    /*------------------- JUGADOR ---------------------------*/

    public void ReconocerJugador(PlayerController player)
    {
        jugadorPC = player;
    }

    public void CambioMov()
    {
        mov = !mov;
    }

    public bool Block()//Del cambio de movimiento
    {
        return mov;
    }

    /*------------------- UI MANAGER ---------------------------*/

    public void SetUIManager (UIManager ui)
    //Actualiza un nuevo UIManager (en cada cambio de escena)
    {
        uimanag.MuestraVidas(ui.GetLives()); //
        uimanag.MuestraBaterias(ui.GetLives()); //
        uimanag.MuestraPunt(punt);
        uimanag = ui;
    }

    /*------------------- SPAWN ---------------------------*/

    public void GuardaSpawn(Vector2 posJugador)
    {
        spawn = posJugador;
    }

    public Vector2 GetSpawn()
    {
        return spawn;
    }

    /*------------------- DOBLE SALTO ---------------------------*/

    public void ActivarDobleSalto()
    //Activa la habilidad de doble salto al coger el item
    {
        Debug.Log("Doble salto adquirido");
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
}