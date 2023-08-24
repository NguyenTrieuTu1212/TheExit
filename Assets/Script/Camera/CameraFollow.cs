using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : FollowObject
{
    public Transform Target;
    [Range(0f, 10f)]
    public float Smooth;
    public Vector3 offset = new Vector3(0f, 0f,-10f);
    public Vector3 MinVal;
    public Vector3 MaxVal;
    protected override void Awake()
    {
        transform.position = Target.position + offset;
    }
    
    protected override void Follow()
    {
        Vector3 TargetPos = Target.position + offset;
        Vector3 BoundPos = new Vector3(
            Mathf.Clamp(TargetPos.x, MinVal.x, MaxVal.x),
            Mathf.Clamp(TargetPos.y, MinVal.y, MaxVal.y),
            Mathf.Clamp(TargetPos.z, (MinVal+offset).z, (MaxVal+offset).z)
            );   
        Vector3 SmoothPos = Vector3.Lerp(transform.position, BoundPos, Smooth * Time.deltaTime);
        transform.position = SmoothPos;
    }
}
