using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public playerAttack PA;
    public GameObject HitParticle;


    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy") 
        {
            Debug.Log("Enemy");
            Instantiate(HitParticle, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}
