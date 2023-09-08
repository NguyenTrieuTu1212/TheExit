using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMovement : MonoBehaviour
{
    const string DIRECTION = "ChangeDirectionASpiderAnim";
    [Header("---------------- Enermy Patrol ---------------\n")]

    [SerializeField] Rigidbody2D rbSpider;
    [SerializeField] Transform groudDetection;
    [SerializeField] Transform wallDectection;
    [SerializeField] Animator animSpider;
    [Range(-10f, 10f)] public float speedMove;
    [Range(0f, 10f)] public float distanceRaycast;
    [Range(0f, 10f)] public float radiusRayCast;
    public RaycastHit2D platformInfor;
    public LayerMask whatIsWall;
    public bool isTouchWall;
    public bool isMoivingRight = true;

    [Header("-------------- Enermy Follow Target ---------------\n")]
    [SerializeField] public Transform target;
    [SerializeField] public Transform targetDetection;
    [Range(0f, 10f)] public float speedChase;
    [Range (0f,10f)] public float RadiusDistanceDetection;
    [Range(0, 10f)] public float Height;
    [Range(0, 20f)] public float Width;

    public bool isDetectionTarget;
    public LayerMask whatIsTarget;
    

    private void Awake()
    {
        rbSpider = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        groudDetection = transform.Find("GroundDetection");
        wallDectection = transform.Find("WallDetection");
        targetDetection = transform.Find("TargetDetection");
        /*animSpider = GameObject.Find("Spider").GetComponent<Animator>();*/
    }

    
    private void FixedUpdate()
    {
        CheckDetectionTarget();
        if (isDetectionTarget)
        {
            Spider_Follow_Target();
        }
        else
        {
            if ((speedMove < 0 && isMoivingRight) || (speedMove > 0 && !isMoivingRight))
                Flip();
            Spider_Patrol();
        }
        
    }
    
    // ============================================ Spider Follow Target =================================

    private void Spider_Follow_Target()
    {
        rbSpider.velocity = new Vector2(speedChase, rbSpider.velocity.y);
        animSpider.SetInteger("State", 0);
        if (target.position.x > transform.position.x)
        {
            // Spider redirect when detect player
            rbSpider.velocity = new Vector2(speedChase, rbSpider.velocity.y);
            if (!isMoivingRight)
            {
                animSpider.SetInteger("State", 1);
                Flip();
            }
        }
        if (target.position.x < transform.position.x)
        {
            // Spider redirect when detect target
            rbSpider.velocity = new Vector2(-speedChase, rbSpider.velocity.y);
            
            if (isMoivingRight)
            {
                animSpider.SetInteger("State", 1);
                Flip();
            }
        }
        
    }
    
    private void CheckDetectionTarget()
    {
        isDetectionTarget = Physics2D.OverlapBox(targetDetection.position, new Vector2(Width, Height), Height / 2, whatIsTarget);
    }

    // =============================================== Spider Patrol =======================================
    private void Spider_Patrol()
    {
        // Check Spider in Platform
        CheckInPlatform();
        // Check spider touch Wall
        CheckTouchWall();
        if (platformInfor.collider || !isTouchWall)
        {
            rbSpider.velocity = new Vector2(speedMove, rbSpider.velocity.y);
            animSpider.SetInteger("State", 0);
        }
        if (!platformInfor.collider || isTouchWall)
        {
            animSpider.SetInteger("State", 1);
            Flip();
            // Spider redirect on touch wall or touch the edge
            speedMove *= -1;
        }
    }
    private void CheckInPlatform()
    {
        platformInfor = Physics2D.Raycast(groudDetection.position, Vector2.down, distanceRaycast);
        
    }
    private void CheckTouchWall()
    {
        isTouchWall = Physics2D.OverlapCircle(wallDectection.position, radiusRayCast, whatIsWall);
    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        isMoivingRight = !isMoivingRight;
    }

    private void OnDrawGizmos()
    {
        // Draw shape check touch wall
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(wallDectection.position, radiusRayCast);

        // Draw shape check detection target
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(targetDetection.position, new Vector3(Width, Height, 0));

    }
}
