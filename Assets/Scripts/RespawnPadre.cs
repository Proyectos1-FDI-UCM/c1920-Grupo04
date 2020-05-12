using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPadre : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.Reconocerespawn(this);
    }
    public void Respawn()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<EnemyRespawn>())
            {
                child.GetComponent<EnemyRespawn>().Respawn();
            }

            /*
            child.GetComponent<EnemyRespawn>().Respawn();
            GetComponent<EnemyRespawn>().Respawn(); */
        }
    }
}
