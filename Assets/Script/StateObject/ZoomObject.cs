using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public abstract class ZoomObject : GameBehaviour
{
    
    private void Update()
    {
        if (isZoom())
        {
            camZoom();
        }
    }
    abstract protected void camZoom();
    abstract protected bool isZoom();
}
