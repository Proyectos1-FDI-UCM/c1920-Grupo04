using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    //este es el gameobject del jugador
    //public GameObject PC; 
    //esto es la pantalla de fin del juego
    public GameObject EndUI;
    //este booleano es para saber si ha terminado el nivel (de momento no tiene uso, esto se usara cuando haya mas niveles)
    public static bool levelFinished = false;

    //esto es para regresar al menu principal
    public void returnMenu () {
        Time.timeScale = 1f;

        //esto destruye el GameManager antes de que se cargue la escena del menu para que no cause problemas
        //si se quiere empezar una nueva partida
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene(0);
    }

    public void Level2() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    //este metodo es para que cuando el jugador toque el trigger se abra el menu del fin del juego
    private void OnTriggerEnter2D(Collider2D collision) {
        //if (collision.gameObject == PC) {
            EndUI.SetActive(true);
            Time.timeScale = 0f;
        //}
    }

}
