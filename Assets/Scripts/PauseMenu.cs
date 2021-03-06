﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    //booleano para saber si el juego esta pausado o no
    public static bool gameIsPaused = false;
    //gameobject menu de pausa
    public GameObject pauseMenuUI;
    //slider para cambiar el volumen
    public Slider masterSlider;
    //AudioMixer
    public AudioMixer audioMixer;

    public void Start() {
        masterSlider.value = PlayerPrefs.GetFloat("volume", 0f);
        audioMixer.SetFloat("volume", masterSlider.value);
    }

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

        AudioManager.instance.PlaySound("DBala", "play");
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
        AudioManager.instance.PlaySound("seleccion", "play");
        gameIsPaused = false;
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //este metodo carga la escena del menu al pulsar el boton
    public void LoadMenu() {
        Debug.Log("Loading menu ...");
        AudioManager.instance.PlaySound("DBala", "play");
        Time.timeScale = 1f;
        //GameManager para poder destruirlo al volver al menu
        Destroy(GameManager.instance.gameObject);
        SceneManager.LoadScene(0);
    }
    public void SetVolume(float volume) {
        PlayerPrefs.SetFloat("volume", volume);
        audioMixer.SetFloat("volume", volume);
    }
}
