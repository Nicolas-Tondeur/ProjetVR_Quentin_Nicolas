using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    [SerializeField] private float damageAmount = 30f;


    private void OnTriggerEnter(Collider player){
        if(player.tag == "Player"){
            player.GetComponent<HealthPlayer>().TakeDamage(damageAmount);
        }
    }
}
