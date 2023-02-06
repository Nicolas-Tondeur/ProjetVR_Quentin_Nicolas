using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float health = 50;

    public void TakeDamage(float amount, GameObject bodyPartHIT)
    {
        float totalDamage = 0;

        if(bodyPartHIT.tag == "Untagged")
        {
            totalDamage = amount;
        }

        if (bodyPartHIT.tag == "Head")
        {
            totalDamage = amount*3f;
        }

        if (bodyPartHIT.tag == "Foot")
        {
            totalDamage = amount / 2f;
        }


        health -= amount;



        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
