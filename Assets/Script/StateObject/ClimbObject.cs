using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClimbObject : MainPlayer
{

    public float Speed=9f;

    protected virtual void Update()
    {
        CheckIsOnObj();
    }
    protected virtual void FixedUpdate()
    {
        Climb();
    }

    protected virtual void Climb()
    {
        if (CheckIsOnObj())
        {
            rb.isKinematic = true;
            rb.velocity = new Vector2(rb.velocity.x, Speed * InputManegement.Instance.GetVertical());
        }
        else
        {
            rb.isKinematic= false;  
        }
    }
    abstract protected bool CheckIsOnObj();

}
