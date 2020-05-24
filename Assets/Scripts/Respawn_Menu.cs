using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Menu : MonoBehaviour
{
   public void respawn()
    {
        GameManager.instance.RespawnPlayer();
    }
}
