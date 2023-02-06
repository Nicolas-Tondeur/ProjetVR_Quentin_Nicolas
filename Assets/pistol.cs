using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pistol : MonoBehaviour
{

    [SerializeField] GameObject firepoint;
    [SerializeField] float pistolDamage = 15f;

    [SerializeField] GameObject hitFxPrefab;

    [SerializeField] int bulletMax = 7;

    [SerializeField] TextMeshProUGUI currentAmmoUI;
    [SerializeField] TextMeshProUGUI maxAmmoUI;


    int currentBullet;

    [SerializeField] public bool canShoot;

    // float fireRate = .5f;


    private void Start(){
        currentBullet = bulletMax;
        canShoot = false;
        currentAmmoUI.text = currentBullet.ToString("00");
        maxAmmoUI.text = bulletMax.ToString("00");
    }

    public void Tir(){

        if(currentBullet <= 0){
            
            return;
        }

        currentBullet--;
        currentAmmoUI.text = currentBullet.ToString("00");


        RaycastHit hitInfo;

        bool hit = Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hitInfo);

        if(hit){
            GameObject fx = Instantiate(hitFxPrefab,hitInfo.point, Quaternion.Euler(firepoint.transform.forward));
            Destroy(fx, 5f);
        }
        
        if(hit && hitInfo.collider.tag == "destructible"){

            Rigidbody rb = hitInfo.transform.gameObject.GetComponent<Rigidbody>();
            rb.AddForceAtPosition(firepoint.transform.forward * 10, hitInfo.point, ForceMode.Impulse);
        }

        if(hit && hitInfo.transform.gameObject.tag == "enemy"){
            enemyHealth eh = hitInfo.transform.gameObject.GetComponent<enemyHealth>();
            eh.TakeDamage(pistolDamage, hitInfo.collider.gameObject);
        }
    }

    // public void Update(){
    //     if(canShoot){

    //         if(currentBullet <= 0){
                
    //             return;
    //         }

    //         currentBullet--;
    //         currentAmmoUI.text = currentBullet.ToString("00");


    //         RaycastHit hitInfo;

    //         bool hit = Physics.Raycast(firepoint.transform.position, firepoint.transform.forward, out hitInfo);

    //         if(hit){
    //             GameObject fx = Instantiate(hitFxPrefab,hitInfo.point, Quaternion.Euler(firepoint.transform.forward));
    //             Destroy(fx, 5f);
    //         }
            
    //         if(hit && hitInfo.collider.tag == "destructible"){

    //             Rigidbody rb = hitInfo.transform.gameObject.GetComponent<Rigidbody>();
    //             rb.AddForceAtPosition(firepoint.transform.forward * 10, hitInfo.point, ForceMode.Impulse);
    //         }

    //         if(hit && hitInfo.transform.gameObject.tag == "enemy"){
    //             enemyHealth eh = hitInfo.transform.gameObject.GetComponent<enemyHealth>();
    //             eh.TakeDamage(pistolDamage, hitInfo.collider.gameObject);
    //         }
    //     }


    // }

    public void Reload(){
        currentBullet = bulletMax;
        currentAmmoUI.text = currentBullet.ToString("00");

    }
}
