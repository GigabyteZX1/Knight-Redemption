using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    //[SerializeField] private AudioClip fireballSound;
    [SerializeField] private AudioSource fireballSound;
    private float cooldownTimer;

    private void Attack()
    {
        fireballSound.Play();
        // SoundManager.instance.PlaySound(fireballSound);
        // SoundManager.instance.SpatialBlend();
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().AcitivateProjectile();
    }

    private int FindFireball()
    {
        for(int i = 0; i< fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(cooldownTimer >= attackCooldown)
        {
            Attack();
        }
    }
}
