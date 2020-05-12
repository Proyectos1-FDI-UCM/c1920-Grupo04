using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public GameObject enemy;
    bool dead = false;
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
