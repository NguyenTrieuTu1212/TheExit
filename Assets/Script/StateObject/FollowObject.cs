using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowObject : GameBehaviour
{
    private void Update()
    {
        Follow();
    }
    abstract protected void Follow();
}
