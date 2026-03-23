using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird3 : MonoBehaviour
{


public float zıplama_aralıgı;
private Rigidbody2D rb;

void Start()
{
    rb = GetComponent<Rigidbody2D>();
}

void Update()
{
    if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
    {
        rb.velocity = Vector2.up * zıplama_aralıgı;
    }


    float angle = rb.velocity.y * 5f; 
    angle = Mathf.Clamp(angle, -90f, 30f); 

    transform.rotation = Quaternion.Euler(0, 0, angle);
}
}