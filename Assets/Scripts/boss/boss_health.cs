using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_health : MonoBehaviour
{
    public int health = 500;
    public GameObject minionPrefab;
    public Slider healthBar;
    //public GameObject deathEffect;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private int pointsToGive;
    private Animator animator;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();  
    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(Invulnerability());
        health -= damage;
        healthBar.value = health;
        SoundManager.instance.PlaySound(hurtSound);
        animator.SetTrigger("Hurt");
        if (health <= 200)
        {
            animator.SetBool("IsEnraged", true);
            
        }
        if(health<=0)
        {   
            Die();
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6,7, true);
        for (int i=0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1,0,0,0.5f);  //setting red flashing color while invulnerability is active
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes *2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes *2));
        }
        Physics2D.IgnoreLayerCollision(6,7, false);

    }

    void Die()
    {
        //SoundManager.instance.PlaySound(deathSound);
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        for (int i = 0; i < 4; i++)
            {
                GameObject b = Instantiate(minionPrefab) as GameObject;
                b.transform.position = transform.position;
            }
        animator.SetBool("isDead", true);
        Score.instance.AddPoint(pointsToGive);
        Destroy(gameObject);
    }
}
