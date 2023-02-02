using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pistol : MonoBehaviour
{
    [SerializeField] GameObject firepoint;
    [SerializeField] float pistoldamage = 15f;
    // [SerializeField] GameObject hitFxPrefab;
    [SerializeField] int bulletMax = 7;
    [SerializeField] TextMeshProUGUI currentAmmoUI ;
    [SerializeField] TextMeshProUGUI maxAmmoUI;
    int currentBullet;
    private void Start()
    {
        currentBullet = bulletMax;
        maxAmmoUI.text = bulletMax.ToString("00");
        currentAmmoUI.text = currentBullet.ToString("00");
    }
    public void Tir()
    {
        if (currentBullet <= 0) return;
        Debug.Log("shoot");
        currentBullet--;
        currentAmmoUI.text = currentBullet.ToString("00");
        RaycastHit hitinfo;

        bool hit = Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hitinfo);
        //if (hit){
           // GameObject fx = Instantiate(hitFxPrefab, hitinfo.point, Quaternion.Euler(firepoint.transform.forward));
        //}
        if(hit && hitinfo.collider.tag == "Destructible")
        {
            Rigidbody rb = hitinfo.transform.gameObject.GetComponent<Rigidbody>();
            rb.AddForceAtPosition(firepoint.transform.forward * 10, hitinfo.point,ForceMode.Impulse);
        }

        if (hit && hitinfo.transform.gameObject.tag == "Enemy")

        {

            EnemyHealth eh = hitinfo.transform.gameObject.GetComponent<EnemyHealth>();
            eh.TakeDamage(pistoldamage, hitinfo.collider.gameObject);



        }

    }
    public void Reload()
    {
        currentBullet = bulletMax;
        currentAmmoUI.text = currentBullet.ToString("00");
    }


      
  

}
