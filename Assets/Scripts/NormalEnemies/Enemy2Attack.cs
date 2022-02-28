using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
    public float attackDamage = 2f;
    public Vector3 attackOffset;
    public float attackRange = 0.5f;
    public LayerMask attackMask;

    public void Attack2()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
        Collider2D colInfo2 = Physics2D.OverlapCircle(-pos, attackRange, attackMask);
        if (colInfo2 != null)
        {
            colInfo2.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }
    }
}
