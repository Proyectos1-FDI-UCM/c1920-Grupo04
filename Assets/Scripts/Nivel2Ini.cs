using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel2Ini : MonoBehaviour
{
    //Se produce tras 0.2 segundos, debido a que si lo haces en el start, todavía no se ha inicializado el UIManager etc
    float timer;
    void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.02f)
        {
            //Inicializa las habilidades de Spark, en caso de empezar directamente en este nivel
            PlayerController.instance.Nivel2Inicializacion();
            GameManager.instance.Nivel2Inic();

            Destroy(this.gameObject);
        }
    }

}
