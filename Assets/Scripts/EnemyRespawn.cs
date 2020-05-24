using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    GameObject enemy;
    bool dead = false;
    private void Start()
    {        
        enemy = transform.GetChild(0).gameObject;
    }
    public void Respawn()
    {
        if (dead)
        {
            Instantiate(enemy, gameObject.transform);
            dead = false;
        }
    }
    public void IsDead()
    {
        dead = true;
    }
}
