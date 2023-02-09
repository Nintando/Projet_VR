using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{

    [SerializeField] float maxHealth = 100;

    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log(currentHealth);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
