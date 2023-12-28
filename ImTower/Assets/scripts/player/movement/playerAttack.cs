using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    playerMovement playermovement;

    public GameObject character;
    public GameObject weapon;
    public bool canAttack = true;
    public float AttackCooldown = 2f;

    public float Attackduration = 2f;

    public Animator animator;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        playermovement = GetComponent<playerMovement>();

        animator = character.GetComponent<Animator>();
    }

    
    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {

                Attack();
            }
            else
            {
                animator.SetBool("Attack", false);
            }
        }
    }

    private void Attack()
    {
        
       
        canAttack = false;
        animator.SetBool("Attack", true);
        animator.SetBool("Walk", false) ;
        playermovement.groundDrag = 10f;

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);

        playermovement.groundDrag = 2.5f;
        animator.SetBool("Attack", false );
        canAttack = true;
    }
}


