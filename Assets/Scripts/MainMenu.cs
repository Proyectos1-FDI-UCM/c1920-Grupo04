using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider masterSlider;
    public AudioMixer audioMixer;  
    


    public void Start() {
        //aqui uso PlayerPrefs para que recoja el volumen que tiene que tener el juego 
        //para que el slider este con ese valor cuando se regrese a opciones
        masterSlider.value = PlayerPrefs.GetFloat("volume", 0f);
        audioMixer.SetFloat("volume", masterSlider.value);
    }

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
        Instantiate(click);
    }
    //este es el metodo que usa el slider para cambiar el volumen del juego
    public void SetVolume(float volume) {
        //aqui asigno el nuevo valor del volumen en PlayerPrefs para que se pueda acceder a el 
        //en cualquier momento y que se mantenga entre escenas
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", volume);
        
    }
}
