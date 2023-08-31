using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveObject : MonoBehaviour
{

    protected virtual void FixedUpdate()
    {
        MoveFlatforms();
    }
    abstract protected void MoveFlatforms();
    
}
