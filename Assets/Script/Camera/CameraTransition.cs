using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    [SerializeField] private CameraFollow cameraFollow;
    [Range(0f, 10f)] public float delayTransition;
    [SerializeField] private GameObject target;
    
    
    public bool isDetectPlayer;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TimeWaitTransition());
        }
    }


    IEnumerator TimeWaitTransition()
    {
        cameraFollow.Target = target.transform;
        yield return new WaitForSeconds(delayTransition);
        cameraFollow.Target = GameObject.FindWithTag("Player").transform;
        Collider2D coll = gameObject.GetComponent<Collider2D>();
        coll.enabled = false;
    }


}
