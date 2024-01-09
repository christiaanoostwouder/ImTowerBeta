using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    playerMovement playermovement;
    Orientation orientation;

    public int maxHealth = 100;
    public int currentHealth;

    public Rigidbody rb;

    public Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        playermovement = GetComponent<playerMovement>();
        orientation = GetComponent<Orientation>();
    }


    void Update()
    {

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) 
        {
            rb.velocity = Vector3.zero; // Stop linear movement
            rb.angularVelocity = Vector3.zero; // Stop angular movement
            rb.freezeRotation = true; // Freeze rotation
            playermovement.groundDrag = 100f;
            anim.SetBool("Die", true);
        }
    }
}
