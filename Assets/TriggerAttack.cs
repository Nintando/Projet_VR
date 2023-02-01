using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAttack : MonoBehaviour
{
    [SerializeField] float damageAmount = 30;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<HealthPlayer>().TakeDamage(damageAmount);
        }
    }
}
