using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    public float ziplamaKuvveti = 3f;
    bool basildiMi = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            basildiMi = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            basildiMi = false;
        }
    }

    private void FixedUpdate()
    {
        if (basildiMi)
        {
            rb.velocity = Vector2.up * ziplamaKuvveti;
        }
        
    }
}
