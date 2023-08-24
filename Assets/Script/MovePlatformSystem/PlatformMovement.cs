using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] Transform pointA, pointB;
    [Range(0f, 10f)] public float speedPlatform;
    [Range(1f, 10f)] public float timeStartMoving;
    private Vector3 targetPos;


    public PlayerMovement playerMovement;
    public GlowLights lights;
    public Rigidbody2D rbDynamicPlatform;
    private Vector3 moveDirection;


    private void Awake()
    {
        pointA = GameObject.Find("Point_A").GetComponent<Transform>();
        pointB = GameObject.Find("Point_B").GetComponent<Transform>();
        playerMovement = GameObject.Find("Movement").GetComponent<PlayerMovement>();
        lights = GameObject.Find("StreetLamp").GetComponent<GlowLights>();
    }
    private void Start()
    {
        targetPos = pointB.position;
        DierectionCaculate();
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < 0.05f)
        {
            targetPos = pointB.position;
            DierectionCaculate();
        }
        if (Vector2.Distance(transform.position, pointB.position) < 0.05f)
        {
            targetPos = pointA.position;
            DierectionCaculate();
        }
    }

    private void FixedUpdate()
    {
        MovingPlatform();
    }


    private void MovingPlatform()
    {
        if (lights.isLightUp)
        {
            timeStartMoving -= Time.deltaTime;
            if(timeStartMoving <= 0)
            {
                rbDynamicPlatform.velocity = moveDirection * speedPlatform;
                timeStartMoving = 0;
            }
            
        }
        
    }
    private void DierectionCaculate()
    {
        moveDirection = (targetPos - transform.position).normalized;
    }
     
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.isOnDynamicPlatform = true;
            playerMovement.rbDynamicPlatform = rbDynamicPlatform;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.isOnDynamicPlatform = false;
            
        }
    }
}
