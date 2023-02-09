using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{


    [SerializeField] float health = 50;
    private Rigidbody[] _ragdollRigidbodies;
    // Start is called before the first frame update
    public void Awake()
    {
        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    

    private void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void TakeDamage(float amount, GameObject bodyPartHit)
    {
        float totalDamage = 0;

        if (bodyPartHit.tag == "untagged")
        {
            totalDamage = amount;
        }


        if (bodyPartHit.tag == "Head")
        {
            totalDamage = amount * .3f;
        }
        if (bodyPartHit.tag == "Armor")
        {
            totalDamage = amount * .5f;
        }



        health = -totalDamage;
        if (health <= 0)
        {
            EnableRagdoll();
        }




    }


}
