using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<playerhealth>();
            Debug.Log("Damage");
            healthComponent.TakeDamage(20);
        }
    }
}
