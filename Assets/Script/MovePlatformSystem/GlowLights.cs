using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowLights : MonoBehaviour
{
    const string TURN_OFF = "TurnOffTheLight";
    const string TURN_ON = "TurnOnTheLight";
    
    public Animator glowAnim;
    public bool isLightUp =false;
    

    private void Awake()
    {
        glowAnim = GameObject.FindWithTag("Glow").GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isLightUp)
        {
            glowAnim.Play(TURN_OFF);
        }
        if (isLightUp)
        { 
            glowAnim.Play(TURN_ON);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Firefly")) isLightUp = true;
    }
}
