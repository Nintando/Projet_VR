using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float health = 50;
    // Start is called before the first frame update
    public void TakeDamage(float amount, GameObject bodyPartHit)
    {
        float totalDamage = 0;
        
        if (bodyPartHit.tag == "untagged")
        {
             totalDamage = amount;
        }
    

        if (bodyPartHit.tag == "Head")
        {
            totalDamage = amount* .3f;
        }
        if (bodyPartHit.tag == "Armor")
        {
            totalDamage = amount * .5f;
        }



        health = -totalDamage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }




    }

    
}
