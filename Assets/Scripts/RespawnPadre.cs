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
        for (int i = 0; i < transform.childCount; i++)
        {
            foreach (Transform child in transform.GetChild(i))
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
}
