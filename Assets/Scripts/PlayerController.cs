using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float vel, forceJump;
    Rigidbody2D rb;
    float deltaX;
    bool salto;
    private Vector2 scale;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
    }
    void Update()
    {
        deltaX = Input.GetAxis("Horizontal");
        setScale();
        salto = Input.GetAxis("Jump") == 1;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(deltaX*vel, rb.velocity.y);

        if (GameManager.instance.TieneEnergia() && salto && (Mathf.Abs(rb.velocity.y) < 0.01f))

        {
            GameManager.instance.EnergiaSuma(-1);
            rb.AddForce((Vector2.up) * forceJump, ForceMode2D.Impulse);
        }

    }
    // Configura la escala de Spark. Hacia dónde mira.
    private void setScale()
    {
        if (deltaX < 0)
            transform.localScale = scale * new Vector2(-1, 1);
        else if (deltaX > 0)
            transform.localScale = scale;
    }

}

