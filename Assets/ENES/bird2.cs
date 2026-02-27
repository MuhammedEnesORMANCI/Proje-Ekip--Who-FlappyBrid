using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird2 : MonoBehaviour
{


    public float zıplama_aralıgı;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * zıplama_aralıgı;
            anim.SetTrigger("Flap");
        }
}
}