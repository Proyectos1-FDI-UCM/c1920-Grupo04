﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public GameObject[] objetivo;
    public bool isInside;
    public GameObject bala;
    public bool hasDoor;
    public float nextTimeDoorCanOpen; //nDT es next door activation time y sirve para que no se active Interact si no ha acabado la animacion de la puerta
    private void Start() {
        nextTimeDoorCanOpen = 0;
    }
    void Update () {

        if (Input.GetKeyDown(KeyCode.E) && isInside == true) {
            if (hasDoor == false) { 
                Pressed();
            }
            else if (hasDoor == true && Time.time > nextTimeDoorCanOpen) {
                nextTimeDoorCanOpen = Time.time + 1f;
                Pressed();
            }

        }
        
    }
    void Pressed() { //este es el metodo que activa y desactiva el script Interact de los objetos que estan conectados al interruptor
        int n = objetivo.Length;
        for (int i = 0; i < n; i++) {
            if (objetivo[i].GetComponent<Interact>().enabled == true) {
                objetivo[i].GetComponent<Interact>().enabled = false;
            }
            else {
                objetivo[i].GetComponent<Interact>().enabled = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        isInside = true;
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == bala.GetComponent<SpriteRenderer>().sprite) {
            
            Pressed();
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isInside = false;
    }
}
