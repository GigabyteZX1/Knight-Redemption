using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] private Vector2 BossPos;
    [SerializeField] private GameObject Boss;
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player")
        {
            spawnBoss();
            Destroy(gameObject);
        }
    }

    private void spawnBoss()
    {
        GameObject a = Instantiate(Boss) as GameObject;
        a.transform.position = new Vector2(BossPos.x, BossPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
