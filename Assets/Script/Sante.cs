using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sante : MonoBehaviour
{

    [SerializeField]
    Slider sliderVie;

    [SerializeField]
    Slider sliderShield;

    [SerializeField]
    Text textVie;

    [SerializeField]
    float startHealth;

    [SerializeField]
    float startShield = 0;

    [SerializeField]
    ParticleSystem deathParticle;



    float currentHealth;
    float currentShield = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = startHealth;
        sliderVie.maxValue = startHealth;
        sliderVie.value = startHealth;
        sliderShield.value = startShield;
        textVie.text = startHealth + "%";
    }
    
    public void DoDamage(float damage)
    {
        if(currentShield > 0)
        {
            currentShield -= damage;
            sliderShield.value = currentShield;
        }
        else
        {
            currentHealth -= damage;
            sliderVie.value = currentHealth;
            if (gameObject.tag == "Player")
            {
                textVie.text = currentHealth + "%";
            }

            if (currentHealth <= 0)
            {
                if (gameObject.tag == "Player")
                {
                    SceneManager.LoadScene(3);
                }

               

           
                Destroy(gameObject);

            }
        }
    }

    public void heal(float healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > startHealth)
        {
            currentHealth = startHealth;
        }

        sliderVie.value = currentHealth;
        textVie.text = currentHealth + "%";
    }
    public void shield(float shieldAmount)
    {
        currentShield += shieldAmount;

        if (currentShield < startShield)
        {
            currentShield = startShield;
        }

        sliderShield.value = currentShield;
    }

}
