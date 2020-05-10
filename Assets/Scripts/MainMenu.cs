using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer; 
    //este metodo es para empezar el juego al hacer que se cargue la escena Nivel 1 y tambien lo voy a usar para
    //cargar el primer nivel en el menu de seleccion de niveles
    public void NewGame() {
        SceneManager.LoadScene(1);
        Sound();
    }
    //El metodo QuitGame sirve para salir del juego pero en el editor no se cerrara el juego pero si ocurrira 
    //cuando se haga la build del juego
    public void QuitGame() {
        Sound();
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
    public void Sound() //Metodo al que hay que llamar en cada boton
    {
        AudioManager.instance.PlaySound("seleccion", "play");
    }
    //este es el metodo que usa el slider para cambiar el volumen del juego
    public void SetVolume(float volume) {
        audioMixer.SetFloat("volume", volume);
    }
}
