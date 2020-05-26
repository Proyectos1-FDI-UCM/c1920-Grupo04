using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown_Salto : MonoBehaviour
{
    Slider relleno;
    public float time;

    void Start()
    {
        relleno = transform.GetChild(0).GetComponent<Slider>();
        relleno.value = 0;
        time = 0;
    }

    //void Update()
    //{
    //    if (!GameManager.instance.puedeDSalto())
    //    {
    //        if (time < 0)
    //        {
    //            time = 0;
    //            GameManager.instance.freeDSalto(); //desbloquea DSalto
    //            relleno.value = 0;
    //        }
    //        else if (time == 0)
    //        {
    //            time = 0.25f;
    //            relleno.value = 1;
    //        }
    //        else if (time > 0)
    //        {
    //            relleno.value = time / 1.5f;
    //            time -= Time.deltaTime;
    //        }
    //    }
    //}
}


































///@Acedpol
