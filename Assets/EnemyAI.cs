using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;

    [SerializeField] private float attackDelay = 3f;

    private NavMeshAgent nma; 
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        //nma = gameObject.GetComponent<NavMeshAgent>();
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

    private void Attack()
    {
        if (isInRange())
        {
            t += Time.deltaTime;

            if(t >= attackDelay)
            {
                animator.SetTrigger("Attack");
                t = 0;
            }
        }
    }

    private void Animation()
    {
        animator.SetBool("inRange", isInRange());
    }

    private void Movement()
    {
        nma.SetDestination(player.transform.position);
    }

    private bool isInRange()
    {
        return nma.hasPath && nma.remainingDistance < nma.stoppingDistance;
    }
}
