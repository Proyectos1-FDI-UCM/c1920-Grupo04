using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPool : MonoBehaviour
{
    public static ShotPool instance;
    private void Awake()
    {
        //Un único ShotPool:
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
