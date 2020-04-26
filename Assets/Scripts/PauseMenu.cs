using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //booleano para saber si el juego esta pausado o no
    public static bool gameIsPaused = false;
    //gameobject menu de pausa
    public GameObject pauseMenuUI;
   
    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            
            if (gameIsPaused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }
    //al hacer publico el metodo Resume puedo asignarselo a un boton para que continue el juego cuando lo pulse 
    public void Resume() {
        //esto quita el menu de pausa de la pantalla
        pauseMenuUI.SetActive(false);
        //al poner el Time.timeScale a 1 el juego empezara a moverse con normalidad
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        //esto hace que aparezca en la pantalla el menu de pausa
        pauseMenuUI.SetActive(true);
        //al poner el Time.timeScale a 0 esto hace que se quede parado el juego y que no se pueda mover nada
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    //este metodo reinicia el nivel y recarga la vida y la energia del jugador a como estaba al inicio
    public void Restart() {
        Time.timeScale = 1f;
        gameIsPaused = false;
        int cantidad = GameManager.instance.EnergiaParaSumar();
        GameManager.instance.EnergiaSuma(cantidad);
        GameManager.instance.ChangeVida(-3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //este metodo carga la escena del menu al pulsar el boton
    public void LoadMenu() {
        Debug.Log("Loading menu ...");
        
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
