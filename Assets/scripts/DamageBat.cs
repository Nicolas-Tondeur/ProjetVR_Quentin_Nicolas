using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DamageBat : MonoBehaviour
{
    [SerializeField] private float damageAmountBat = 10f;
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider other){
         if(other.tag == "Head" || other.tag == "Legs" || other.tag == "Body"){
            Debug.Log("Hit" + other.transform.gameObject.tag);               
            other.gameObject.SendMessageUpwards("TakeDamageBat", damageAmountBat);
        }
        if(other.tag == "TrainingModel"){
            animator.SetTrigger("Hit");
        }
    
    }    
}
