using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    public Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Animator animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        float speed = rb.velocity.magnitude;
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk",true);
        }
        else
        {
            animator.SetBool("Walk", false);
            
        }

        if (Input.GetKey(KeyCode.LeftShift)&& speed > 2f)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            animator.SetBool("Walk", false);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        

    }
}
