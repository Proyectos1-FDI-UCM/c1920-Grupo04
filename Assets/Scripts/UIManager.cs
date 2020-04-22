using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] lives;
    public Image[] bat;
    public Text scoreText;
    private int nBats = 0; //Recordar cuantas energias tenemos (min = 3)
    private int nLives = 0; //Recordar cuantas vidas tenemos (min = 3)
    private const int MAX_BAT = 10; // Máxima cantidad en todo el juego
    private const int MAX_LIFE = 6; // Máxima cantidad en todo el juego
    private int max_bat = 0; // antiguo: maxbat (máxima cantidad actual)
    private int max_life = 0; // (máxima cantidad actual)

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetUIManager(this);
        nBats = bat.Length; //
        max_bat = nBats; //
        nLives = lives.Length; //
        max_life = nLives; //
    }

    // antiguo: masEnergia
    public void añadeBaterias(int add)
    {
        //maxbat = 8;
        //bat7.enabled = false; //Cambiar el fondo de las baterias
        //bat8.enabled = true;
        // Limitando el máximo de vidas en total.
        if (add + max_bat <= MAX_BAT)
            max_bat += add;
        else
            max_bat = MAX_BAT;
        // Devuelve a true solo los valores en false.
        for (int i = nBats; i < max_bat; i++) 
        {
            bat[i].GetComponent<Image>().enabled = true;
        }
    }

    public void DevuelveEnergia(int energy)
    {
        int dif = energy - aux;
        for(int i = 0; i < dif; i++)
        {
            bat[energy - i - 1].enabled = true;
        }
    }

    // antiguo: EnseñaVidas
    public void MuestraVidas(int vidas)
    //Actualiza las vidas en el HUD
    {
        if (vidas <= 2) lives[0].enabled = false;
        if (vidas <= 1) lives[1].enabled = false;
        if (vidas <= 0) lives[2].enabled = false;
    }

    // antiguo: EnseñaBaterias
    public void MuestraBaterias(int baterias)
    //Actualiza las baterías en el HUD
    {
        aux = baterias;
        if (maxbat == 7)
        {
            if (baterias == 6) bat[6].enabled = false;
            else if (baterias == 5) bat[5].enabled = false;
            else if (baterias == 4) bat[4].enabled = false;
            else if (baterias == 3) bat[3].enabled = false;
            else if (baterias == 2) bat[2].enabled = false;
            else if (baterias == 1) bat[1].enabled = false;
            else if (baterias == 0) bat[0].enabled = false;
        }
        else
        {
            if (baterias == 7) batextra.enabled = false;
            else if (baterias == 6) bat[6].enabled = false;
            else if (baterias == 5) bat[5].enabled = false;
            else if (baterias == 4) bat[4].enabled = false;
            else if (baterias == 3) bat[3].enabled = false;
            else if (baterias == 2) bat[2].enabled = false;
            else if (baterias == 1) bat[1].enabled = false;
            else if (baterias == 0) bat[0].enabled = false;
        }
    }

    // aantiguo: EnseñaPunt
    public void MuestraPunt(int puntuacion)
    //Actualiza la puntuación en el HUD
    {
        scoreText.text = "Points: " + puntuacion.ToString();
    }

    //
    public int GetLives()
    {
        return nLives;
    }
    
    //
    public int GetBateries()
    {
        return nBats;
    }
    
    //
    public int GetMaxBat()
    {
        return max_bat;
    }
    
    //
    public int GetMaxLife()
    {
        return max_life;
    }

    //
    public void SetBats(int bats)
    {
        nBats += bats;
    }
}
