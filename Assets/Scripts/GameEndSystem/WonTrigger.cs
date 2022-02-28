using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonTrigger : MonoBehaviour
{
    public GameWon gameWon;
    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.tag == "Player")
        {
            gameWon.Setup();
            
        }
    }
}
