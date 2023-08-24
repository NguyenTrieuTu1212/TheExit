using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWayPoint : MonoBehaviour
{
    
    [SerializeField] Transform[] wayPoint;
    [SerializeField] Rigidbody2D rbTarget;
    [SerializeField] int wayPointIndex=0;
    [SerializeField] Animator animatorFirefly;
    [SerializeField] bool isFlyingStart;
    [Range(0,10f)] 
    public float speedFly;
    public CameraFollow camFollow;
    [Range (0,10f)]
    public float timeTransition;
    private void Awake()
    {
        rbTarget = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        transform.position = wayPoint[wayPointIndex].transform.position;
        animatorFirefly = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if(wayPoint != null && isFlyingStart)
        {
            // When fireflies fly, the player will stop moving ==> lock constraints.X
            rbTarget.constraints = RigidbodyConstraints2D.FreezePositionX;
            // The camera started to follow the fireflies
            camFollow.Target = transform;
            // Move to way point
            MoveToWayPoint();

            timeTransition -= Time.fixedDeltaTime;
            if(timeTransition <= 0)
            {
                isFlyingStart = false;
                // Switch to the normal moving character state
                rbTarget.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
                rbTarget.constraints = RigidbodyConstraints2D.FreezeRotation;
                // The Camera foolow player
                camFollow.Target = GameObject.FindWithTag("Player").transform;
            }
        }
    }

    private void MoveToWayPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoint[wayPointIndex].transform.position,Time.deltaTime * speedFly);
        if (transform.position == wayPoint[wayPointIndex].transform.position) wayPointIndex++;
        if (wayPointIndex == wayPoint.Length)
        {
            wayPointIndex = wayPoint.Length - 1;
            animatorFirefly.enabled = false;
        }
          
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) isFlyingStart = true;
    }
}
