using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomTrigger : MonoBehaviour
{
    public Sprite newSprite;
    public GameObject gate;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(GameObject.Find("Boss(Clone)") == null)
            {
                ChangeSprite();
                gate.GetComponent<Collider2D>().isTrigger = true;
                Destroy(gameObject);
                
            }
        }
    }
    void Update(){

    }

    void ChangeSprite()
    {
        gate.GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}
