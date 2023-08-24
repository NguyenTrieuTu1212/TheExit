using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MainPlayer
{
    [SerializeField] Transform ObjDead;
    [SerializeField] Transform Target;
    [Range(0, 3f)] public float Height;
    [Range(0, 2f)] public float Width;
    public Vector3 posRespawn;
    public Vector3 currentLocalScale;
    public LayerMask WhatIsLayer;
    public bool IsDie = false;
    public bool canReset;
    

    protected override void LoadComponent()
    {
        base.LoadComponent();
        ObjDead = transform.Find("ObjDeadCheck");
        
    }
    private void Start()
    {
        posRespawn = Target.transform.position;
        currentLocalScale = Target.transform.localScale;
    }

    private void Update()
    {
        CheckIsDie();
        PlayerRespawn();
    }
    
    private void CheckIsDie()
    {
        IsDie = Physics2D.OverlapBox(ObjDead.position, new Vector2(Width,Height), Height / 2, WhatIsLayer);
    }

    private void Die()
    {
        Target.transform.position = posRespawn;
    }
    private void PlayerRespawn()
    {
        if (IsDie)
        {
            Die();
            Debug.Log(Target.position);
            canReset = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ObjDead.position, new Vector3(Width, Height, 0));
    }
}
