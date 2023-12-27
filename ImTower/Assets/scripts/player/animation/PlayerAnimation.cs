using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;
    
    void Start()
    {
        Animator animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Walk",true);
        }
        else
        {
            animator.SetBool("Walk", false);
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
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
