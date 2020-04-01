using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// En este script se describirán los movimientos básicos del jugador. Además se administrarán las habilidades.
public class Spark_Manager : MonoBehaviour
{
    // Var. públicas:
    public float velocity, jumpPower;

    // Var. privadas:
    private Rigidbody rb;
    private float translate, jump;
    private Vector2 scale;
    private bool onGround;

    // Start is called before the first frame update.
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        scale = transform.localScale;
    }

    // Update is called once per frame. As fast as can.
    private void Update()
    {
        translate = Input.GetAxis("Horizontal");
        setScale();
        jump = Input.GetAxis("Vertical");
    }

    // FixedUpdate is called once per 0.02 seconds. 50 times per second.
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(translate * velocity, rb.velocity.y);        

        if (jump > 0) // onGround sin tener en cuenta...
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode.Impulse);
        }
    }

    // Configura la escala de Spark. Hacia dónde mira.
    private void setScale()
    {
        if (translate < 0)
            transform.localScale = scale * new Vector2(-1, 1);
        else if (translate > 0)
            transform.localScale = scale;
    }

    // Comprueba si Spark está en el aire.
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor")) // otro modo: (rb.velocity.y == 0f)
    //        onGround = true;
    //    Debug.Log(onGround);
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Floor")) // otro modo: (rb.velocity.y == 0f)
    //        onGround = false;
    //    Debug.Log(onGround);
    //}
}