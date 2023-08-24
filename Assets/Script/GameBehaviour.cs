using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameBehaviour : MonoBehaviour
{
    
    protected virtual void Reset()
    {
        LoadComponent();
        ResetValue();
    }
    protected virtual void Awake()
    {
        LoadComponent();
        ResetValue();
    }
    protected virtual void LoadComponent()
    {
        
    }
    protected virtual void ResetValue()
    {

    }
}
