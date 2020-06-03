using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject Spawn;
    float deltaX;
    Rigidbody2D rb;

    float contador;
    int vel;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        deltaX = 1;
        vel = 4;
        contador = 0;
    }

    private void Update()
    {
        contador += Time.deltaTime;
        if (contador >= 8f)
        {
            contador = 0;
            transform.position = Spawn.transform.position;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(deltaX * vel, rb.velocity.y);
    }
}
