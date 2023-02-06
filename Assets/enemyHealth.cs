using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] float health = 50;

    public void TakeDamage(float amount, GameObject bodyPartHit){

        float totalDamage = 0;

        if(bodyPartHit.tag == "Body"){
            totalDamage = amount;
        }

        if(bodyPartHit.tag == "Head"){
            totalDamage = amount*3f;
        }

        if(bodyPartHit.tag == "Legs"){
            totalDamage = amount*.5f;
        }


        health -= totalDamage;

        if(health <= 0){
            Destroy(gameObject);
        }
    }

    public void TakeDamageBat(float amount){
        float totalDamage = 0;
        totalDamage = amount;

        health -= totalDamage;

        if(health <= 0){
            Destroy(gameObject);
        }

    }
}
