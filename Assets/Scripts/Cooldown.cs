using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    Slider relleno;
    public float time;

    void Start()
    {
        relleno = transform.GetChild(0).GetComponent<Slider>();
        relleno.value = 0;
        time = 0;
    }

    void Update()
    {
        if (!GameManager.instance.puedeDisparo())
        {
            if (time < 0)
            {
                time = 0;
                GameManager.instance.freeDisparo(); //desbloquea disparo
                relleno.value = 0;
            }
            else if (time == 0)
            {
                time = 1.5f;
                relleno.value = 1;
            }
            else if (time > 0)
            {
                relleno.value = time / 1.5f;
                time -= Time.deltaTime;
            }
        }        
    }
}


































///@Acedpol