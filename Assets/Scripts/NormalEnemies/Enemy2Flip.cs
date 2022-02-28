using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Flip : MonoBehaviour
{
    public Transform player;
    public bool isFlipped2 = false;
    public float LeftBound = 10;
    public float RightBound = 20;
    public void LookAtSide()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (transform.position.x >= RightBound && isFlipped2)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped2 = false;
        }
        else if (transform.position.x <= LeftBound && !isFlipped2)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped2 = true;
        }
        /*else if (transform.position.x == (player.position.x + 0.5) && isFlipped2)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped2 = false;
        }
        else if (transform.position.x == (player.position.x - 0.5) && !isFlipped2)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped2 = true;
        }*/
    }
}
