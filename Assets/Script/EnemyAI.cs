using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] float range = 3;

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
    }

    private void Attack()
    {
        if (isInRange())
        {
            t += Time.deltaTime;

            if (t >= attackDelay)
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
        float dist = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(dist <= range);
        if (dist <= range)
        {
            nma.SetDestination(player.transform.position);
        }
        else
        {
            nma.isStopped = false;
        }

    }

    private bool isInRange()
    {
        return nma.hasPath && nma.remainingDistance < nma.stoppingDistance;
    }
}
