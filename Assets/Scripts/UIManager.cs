using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text vidasText;
    public Text bateriasText;
    public Text puntText;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.SetUIManager(this);
    }

    
    public void EnseñaVidas(int vidas, int vidMax)
    //Actualiza las vidas en el HUD
    {
        vidasText.text = "Vidas: " + vidas + " / " + vidMax;
    }

    public void EnseñaBaterias(int baterias, int batMax)
    //Actualiza las baterías en el HUD
    {
        bateriasText.text = "Baterías: " + baterias + " / " + batMax;
    }

    public void EnseñaPunt(int puntuacion)
    //Actualiza la puntuación en el HUD
    {
       // puntText.text = "Puntuación: " + puntuacion;
    }
}
