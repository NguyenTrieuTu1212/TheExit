using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbLadder : ClimbObject
{
    public LayerMask WhatIsLayer;
    public Transform LadderCheck;
    private bool IsLadder;
    [Range(0f, 10f)] public float Distance;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LadderCheck = transform.Find("LadderCheck");
    }
    protected override void Update()
    {
       base.Update();
       Debug.DrawRay(LadderCheck.transform.position,Vector2.up,Color.white);
    }
    
    protected override bool CheckIsOnObj()
    {
        IsLadder= Physics2D.Raycast(LadderCheck.transform.position, Vector2.up, Distance, WhatIsLayer);
        animator.SetBool("IsLadder", IsLadder);
        return IsLadder;
    }

}
