using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;

    private NavMeshAgent nma;
    private float t;
    private float attackDelay;

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


        /* Function to stop enemy in front of the player 
         * 
         * float distance = Vector3.Distance(transform.position, player.transform.position);
         * 
         * if (distance < 5f )
         * {
                nma.isStopped = true;
         *  }
         */
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
        animator.SetBool("InRange", isInRange());
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
