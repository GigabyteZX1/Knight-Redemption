using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Walk : StateMachineBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 0.5f;

    Transform player;
    Rigidbody2D rb;
    Enemy2Flip enemy;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<Enemy2Flip>();


    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.LookAtSide();
        if (enemy.isFlipped2 == true)
        {
            Vector2 target = new Vector2(enemy.RightBound, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        if (enemy.isFlipped2 == false)
        {
            Vector2 target = new Vector2(enemy.LeftBound, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        if (Vector2.Distance(rb.position, player.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }
}

