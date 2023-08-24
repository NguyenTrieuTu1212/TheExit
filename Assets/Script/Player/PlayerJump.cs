using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MainPlayer
{
    private float JumpForce = 20.0f;
    private bool Isground;

    
    [Range(0f, 1f)]
    public float Radius;
    public LayerMask WhatIsGround;
    public Transform GroundCheck;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTranform();
    }

    protected virtual void LoadTranform()
    {
        if (GroundCheck != null) return;
        GroundCheck = transform.Find("GroundCheck");
    }

    private void FixedUpdate()
    {
        CheckIsGround();
        Jump();
    }
    
    private void Jump()
    {
        animator.SetBool("IsJumping",!Isground);
        if (Isground && InputManegement.Instance.GetJumpSignal())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            Isground = false;
        }
    }
    
   
    private void CheckIsGround()
    {
        Isground= Physics2D.OverlapCircle(GroundCheck.position, Radius, WhatIsGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(GroundCheck.position, Radius);
    }

}
