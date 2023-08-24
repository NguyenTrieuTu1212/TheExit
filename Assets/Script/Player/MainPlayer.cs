using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : GameBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadRigibody2D();
        LoadChildRigibody2D();
        LoadAinmator();
    }
    
    protected virtual void LoadRigibody2D()
    {
        if (rb != null) return;
        rb = GetComponent<Rigidbody2D>();
        rb = transform.gameObject.GetComponent<Rigidbody2D>();
        
    }
    protected virtual void LoadChildRigibody2D()
    {
        rb = base.GetComponentInParent<Rigidbody2D>();
    }

    protected virtual void LoadAinmator()
    {
        Animator animator1 = GameObject.Find("Player").GetComponentInChildren<Animator>();
        animator = animator1;
    }
}



