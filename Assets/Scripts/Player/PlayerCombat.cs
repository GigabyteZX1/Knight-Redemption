using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    [SerializeField] private AudioClip swordSound;



    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
          if(Input.GetKeyDown(KeyCode.Space))
          {
              Attack();
              nextAttackTime = Time.time + 1f/attackRate;
              SoundManager.instance.PlaySound(swordSound);
          }
        }
    }
    void Attack()
    {
        
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<EnemyHealth>() != null){
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);

            } else{

                enemy.GetComponent<boss_health>().TakeDamage(attackDamage);
            }
        }

    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;
        
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
