using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManegement : MonoBehaviour
{

    private static InputManegement instance;
    public static InputManegement Instance { get => instance; }

    [SerializeField] private float Horizontal;
    [SerializeField] private float Vertical;
    [SerializeField] private bool JumpSignal;
    private void Awake()
    {
        InputManegement.instance = this;
    }

    private void Update()
    {
        GetHorizontal();
        GetJumpSignal();
        GetVertical();
    }
    public float GetHorizontal()
    {
        Horizontal = Input.GetAxis("Horizontal");
        return Horizontal;
    }

    public float GetVertical()
    {
        Vertical = Input.GetAxis("Vertical");
        return Vertical;
    }
    
    public bool GetJumpSignal()
    {
        if(Input.GetKey(KeyCode.Space)) 
            return true;
        return false;
    }

}
