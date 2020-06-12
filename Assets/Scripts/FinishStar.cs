using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStar : MonoBehaviour
{
    public Sprite finish, unfinish;
    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = finish;
    }

    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().sprite = unfinish;
    }
}
