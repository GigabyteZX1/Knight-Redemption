using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }

    void Update()
    {
        if(transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }

        if(transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed*Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.position.y > transform.position.y)
           {
            collision.transform.SetParent(transform);
           }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);

    }
}
