using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Nicolas{
    public class EnemyAI : MonoBehaviour
    {

        [SerializeField] private GameObject player;         //SerializedField permet d'afficher l'élément dans l'inspector (même en private)
        [SerializeField] private Animator animator;

        [SerializeField] private float attackDelay = 3f;
        private NavMeshAgent nma;                           //nma pour NavMeshAgent
        private float t;

        // Start is called before the first frame update
        void Start()
        {
            nma = GetComponent<NavMeshAgent>();
            nma.isStopped = false;
        }

        // Update is called once per frame
        void Update()
        {

            Movement();
            Animation();
            Attack();

        }

        private void Attack(){
            if(isInRange()){

                t += Time.deltaTime;                    //augmente la variable de temps de 1 par seconde

                if(t >= attackDelay){                   //si mon temps est supérieur au delai pour attaquer
                    animator.SetTrigger("Attack");      //lancer l'animation d'attaque
                    t = 0;                              //reset le temps à 0
                }
            }
        }

        private void Animation(){
            animator.SetBool("InRange", isInRange());
        }

        private void Movement(){
            nma.SetDestination(player.transform.position);
        }

        private bool isInRange(){
            return nma.hasPath && nma.remainingDistance < nma.stoppingDistance;
        }
    }
}