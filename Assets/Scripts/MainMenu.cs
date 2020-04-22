using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //este metodo es para empezar el juego al hacer que se cargue la escena Nivel 1 y tambien lo voy a usar para
    //cargar el primer nivel en el menu de seleccion de niveles
    public void NewGame() {
        SceneManager.LoadScene(1);
    }
    //El metodo QuitGame sirve para salir del juego pero en el editor no se cerrara el juego pero si ocurrira 
    //cuando se haga la build del juego
    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
}
