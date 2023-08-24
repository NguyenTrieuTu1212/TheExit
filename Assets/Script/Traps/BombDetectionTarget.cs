using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetectionTarget : MonoBehaviour
{

    public bool isDetectionTarget;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) isDetectionTarget = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) isDetectionTarget = false;
    }
}
