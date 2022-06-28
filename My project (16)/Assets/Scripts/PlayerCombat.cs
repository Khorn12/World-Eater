using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Animator animator;


    public Transform attackPoint;

    public float  attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttackTime = 0f;
    [SerializeField] private AudioClip attackSound;

    public int attackDamage = 40; 
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
           if(Input.GetMouseButton(0))
           {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
           }
        }
    }

    void Attack()
    {
        //Play an attack animation
        animator.SetTrigger("Attack");
        //Detect enemies i nrange of attack
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position , attackRange , enemyLayers);
        //Damage them
         SoundManager.instance.PlaySound(attackSound);
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

     void OnDrawGizmosSelected()
     {
         if(attackPoint == null)
           return;
         Gizmos.DrawWireSphere(attackPoint.position, attackRange);
     }

}

