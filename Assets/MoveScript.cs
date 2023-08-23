using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController2D controlleer;
    public Animator animator;

     public float runSpeed=40f;

    float horizontalMove=0f;
    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Math.Abs(horizontalMove)); 
        if (Input.GetButtonDown("Jump")){ jump = true; animator.SetBool("isJumping", true); }
        if (Input.GetButtonDown("Crouch")){ crouch = true; animator.SetBool("isCrouching", true); } else if (Input.GetButtonUp("Crouch")) { crouch = false; animator.SetBool("isCrouching", false); }
    }


    public void onLandind()
    {
        animator.SetBool("isJumping", false);
    }
    public void onCrouchind(bool isCrouching)
    {
        animator.SetBool("isCrouching", isCrouching);
    }


    void FixedUpdate()
    {
        controlleer.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
