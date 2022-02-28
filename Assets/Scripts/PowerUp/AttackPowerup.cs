using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPowerup : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public int attackPowerUp;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private AudioClip powerupSound;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            SoundManager.instance.PlaySound(powerupSound);
            playerCombat.attackDamage += attackPowerUp;
            spriteR.color = new Color(1,1,1,0.5f); 
            Destroy(FindObjectOfType<HealthPowerUp>());
            Destroy(gameObject);
        }
    }

}
