using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animator;
    [SerializeField] private AudioClip jumpSound;
    public ParticleSystem dust;
    

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            SoundManager.instance.PlaySound(jumpSound);
            CreateDust();

        }
        if( GetComponent<AudioSource>().isPlaying == false && controller.m_Grounded == true)
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
             GetComponent<AudioSource>().Play();
        }


        }

        
    
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,false, jump);
        jump = false;
    }

    void CreateDust()
    {
        dust.Play();
    }


    
}
