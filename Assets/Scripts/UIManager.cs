using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] lives;
    public Image[] bat;
    public Image bat7;
    public Image bat8;
    public Image batextra;
    public Text scoreText;
    private int aux = 0; //Recordar cuantas energias tenemos
    private int maxbat = 7;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetUIManager(this);
    }

    public void masEnergia(int maximo)
    {
        maxbat = 8;
        bat7.enabled = false; //Cambiar el fondo de las baterias
        bat8.enabled = true;
        for(int i = maximo; aux != i; i--)//Devuelve a true solo los valores en false
        {
            bat[i-1].enabled = true;
        }
    }

    public void DevuelveEnergia(int energy)
    {
        int dif = energy - aux;
        for(int i = 0; i < dif; i++)
        {
            bat[energy - i-1].enabled = true;
        }
    }
    public void EnseñaVidas(int vidas)
    //Actualiza las vidas en el HUD
    {
        Debug.Log(vidas);
        if (vidas <= 2) lives[0].enabled = false;
        if (vidas <= 1) lives[1].enabled = false;
        if (vidas <= 0) lives[2].enabled = false;
    }

    public void EnseñaBaterias(int baterias)
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

    public void EnseñaPunt(int puntuacion)
    //Actualiza la puntuación en el HUD
    {
        scoreText.text = "Points:" + puntuacion.ToString();
    }
}
