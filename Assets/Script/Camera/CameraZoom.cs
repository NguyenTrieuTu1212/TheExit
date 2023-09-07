using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class CameraZoom : ZoomObject
{
    [SerializeField] Camera CamZoom;
    [SerializeField] Rigidbody2D target;
    [SerializeField] bool IsZoomIn=false;
    
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        CamZoom = Camera.main;
        target = GameObject.Find("Player").GetComponent<Rigidbody2D>();
       
    }
    protected override bool isZoom()
    {
        if(target.transform.position.x >= 16f) IsZoomIn = true;
        else if(target.transform.position.x < 16f) IsZoomIn = false;
        return IsZoomIn;
    }
    protected override void camZoom()
    {
        if (IsZoomIn)
            CamZoom.fieldOfView = Mathf.Lerp(CamZoom.fieldOfView, 75f , 0.01f);
        else
            CamZoom.fieldOfView = Mathf.Lerp(CamZoom.fieldOfView, 80f, 0.01f);
    }
 
}
