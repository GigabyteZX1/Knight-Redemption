using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public float attackDamage = 2f;
    private SpriteRenderer spriteRend;

    void Awake()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    

    void Start()
    {
        target = new Vector2(player.position.x, player.position.y); 
        
        spriteRend.flipX = player.transform.position.x < this.transform.position.x;

        
        // if(player.transform.position.y < this.transform.position.y)
        // {
        //     //this.transform.Rotate(Vector3.forward*45);
        //     var angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        //     this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // }

        // if(player.transform.position.y > this.transform.position.y)
        // {
        //     var angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        //     this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target ,speed*Time.deltaTime);
        if(transform.position.x == target.x && transform.position.y == target.y){
            Destroy(gameObject);
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            DestroyArrow();
        }else if(other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
            DestroyArrow();
        }
    }

    void DestroyArrow()
    {
        Destroy(gameObject);
    }

}
