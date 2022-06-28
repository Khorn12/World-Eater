using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;


 public int maxHealth = 100;
 int currentHealth;
   
  [Header("Death Sound")]
   [SerializeField] private AudioClip deathSound;
   [SerializeField] private AudioClip hurtSound;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

   public void TakeDamage(int damage)
   {
       currentHealth -= damage;

       
       animator.SetTrigger("hurt");
       SoundManager.instance.PlaySound(hurtSound);
       if(currentHealth <= 0)
       {
           Die();
       }

   }

   void Die()
   {
       Debug.Log("Enemy died!");
       animator.SetBool("isDead", true);
       SoundManager.instance.PlaySound(deathSound);
       
       
       GetComponent<Collider2D>().enabled = false;
       this.enabled = false;
   }
}
