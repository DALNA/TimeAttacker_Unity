using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    private Animator animator;
    public float speed;
    Rigidbody2D rb2d;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
            animator.SetBool("OnClick", true);
        else
            animator.SetBool("OnClick", false);
    }
}
