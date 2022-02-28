using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    public float currentHealth; //{get; private set;}
    private Animator animator;
    public EnemyHealthBar enemyHealthBar;
    public int pointsToGive;


    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private Rigidbody2D body;
    
    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

        
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        enemyHealthBar.SetHealth(currentHealth, startingHealth);
        StartCoroutine(Invulnerability());
        

        if(currentHealth > 0)
        {
            SoundManager.instance.PlaySound(hurtSound);
            animator.SetTrigger("Hurt");
        }else{
            if(currentHealth<= 0)
            {
                Die();
            } 

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

    void Die(){

        animator.SetBool("isDead", true);
        SoundManager.instance.PlaySound(deathSound);
        body.constraints = RigidbodyConstraints2D.FreezePosition;
        Score.instance.AddPoint(pointsToGive);
        GetComponent<Collider2D>().enabled = false;
    
        
    }
    
}
