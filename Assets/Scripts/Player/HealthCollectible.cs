using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
   [SerializeField] private float healthValue;
   [SerializeField] private AudioClip heartCollect;

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.tag == "Player")
       {
           collision.GetComponent<PlayerHealth>().AddHealth(healthValue);
           SoundManager.instance.PlaySound(heartCollect);
           Destroy(gameObject);
       }

   }
}
