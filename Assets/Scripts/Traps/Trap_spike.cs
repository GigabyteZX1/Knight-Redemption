using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_spike : MonoBehaviour
{
    [SerializeField] protected float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}

