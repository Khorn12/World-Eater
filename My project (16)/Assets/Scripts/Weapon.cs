using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    float nextAttackTime = 2f;
    [SerializeField] private AudioClip attackSound;
    

    // Update is called once per frame
    void Update()
    {  if(Time.time >= nextAttackTime)
    {
        if(Input.GetButtonDown("Fire1"))
        {
            
            Shoot();
        }
    }
    }
   

    void Shoot()
    {
        animator.SetTrigger("attack");

         SoundManager.instance.PlaySound(attackSound);
        
       Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);
    }
}
