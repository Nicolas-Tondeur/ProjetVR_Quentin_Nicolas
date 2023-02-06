using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{

    [SerializeField] float damageAmount = 30;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HealthPlayer>().TakeDamage(damageAmount);
        }
    }

}
