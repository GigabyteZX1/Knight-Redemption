using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float powerUpHealth;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private AudioClip powerupSound;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SoundManager.instance.PlaySound(powerupSound);
            playerHealth.startingHealth += powerUpHealth;
            playerHealth.currentHealth = playerHealth.startingHealth;
            spriteR.color = new Color(1,1,1,0.5f);
            Destroy(FindObjectOfType<AttackPowerup>());
            Destroy(gameObject);
        }
    }

}
