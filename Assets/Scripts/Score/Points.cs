using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    public int points;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Score.instance.AddPoint(points);
            SoundManager.instance.PlaySound(collectSound);
            Destroy(gameObject);

        }
    }
}
