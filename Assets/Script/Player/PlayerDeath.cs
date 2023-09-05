using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MainPlayer
{
    [SerializeField] Transform ObjDead;
    [SerializeField] Transform Target;
    [Range(0, 3f)] public float Height;
    [Range(0, 2f)] public float Width;
    [Range(0,10f)] public float timeWaitRespawn;
    public Vector3 posRespawn;
    public Vector3 currentLocalScale;
    public LayerMask WhatIsLayer;
    public bool IsDie = false;
    public ParticleSystem deadEffectPrefabs;
    
    

    protected override void LoadComponent()
    {
        base.LoadComponent();
        ObjDead = transform.Find("ObjDeadCheck");
        posRespawn = Target.transform.position;
        currentLocalScale = Target.transform.localScale;
       
    }

    /*private void Start()
    {
        posRespawn = Target.transform.position;
        currentLocalScale = Target.transform.localScale;
    }*/

    private void Update()
    {
        CheckIsDie();
        PlayerRespawn();
    }

    private void PlayerRespawn()
    {
        
        if (IsDie) Die();
        
    }

    private void Die()
    {
        deadEffectPrefabs.Play();
        StartCoroutine(WaitRespawn());

    }

    IEnumerator WaitRespawn()
    {
        yield return new WaitForSeconds(timeWaitRespawn);
        Target.transform.position = posRespawn;
    }
    private void CheckIsDie()
    {
        IsDie = Physics2D.OverlapBox(ObjDead.position, new Vector2(Width,Height), Height / 2, WhatIsLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(ObjDead.position, new Vector3(Width, Height, 0));
    }
}
