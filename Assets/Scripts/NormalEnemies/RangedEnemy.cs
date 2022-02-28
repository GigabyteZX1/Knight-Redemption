using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;
    private SpriteRenderer spriteRend;

    public GameObject projectile;
    private Transform player;
    private AudioSource arrow_sfx;

    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        arrow_sfx = GetComponent<AudioSource>();
    }
    

    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position , Quaternion.identity);
            GetComponent<AudioSource>().Play();
            timeBtwShots = startTimeBtwShots;
        }
        else {
            timeBtwShots -= Time.deltaTime;
        }

        spriteRend.flipX = player.transform.position.x < this.transform.position.x;
        
    }

    
}
