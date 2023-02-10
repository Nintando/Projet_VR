using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{

    [SerializeField] int dmg;
    

        private void OnTriggerEnter(Collider other)
        {
        if (other.tag == "Enemy" || other.tag == "Bob")
        {
            Debug.Log(other.transform.gameObject.name);
            other.GetComponent<Animator>().enabled = false;
            other.GetComponent<EnemyHealth>().TakeDamage(dmg, other.gameObject);

        }
            
        }

    }
 
