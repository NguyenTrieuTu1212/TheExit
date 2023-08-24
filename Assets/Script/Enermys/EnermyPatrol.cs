using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyPatrol : GameBehaviour
{

    public bool movingRight = true;
    public bool movingRightInWall = true;

    [SerializeField] Transform groundDetection;
    [SerializeField] Transform wallDetection;
    [SerializeField] Transform targetDetection;
    [SerializeField] Rigidbody2D rbSpider;
    [SerializeField] Animator animSpider;
    [SerializeField] Transform targetFollow;

    public bool checkCollisionWall;
    public bool isDetectionTarget;

    public LayerMask whatIsWall;
    public LayerMask whatIsTarget;
    RaycastHit2D groundInfo;

    [Range(0f, 1f)] public float DistanceRaycast;
    [Range(0f, 10f)] public float speedEnermy;
    [Range(0f, 10f)] public float speedFollow;
    [Range(0, 2f)] public float radius;
    [Range(0, 10f)] public float radiusDetection;
    
    enum SpiderDirectionMoveAnim {Walk,Direction}
    protected override void LoadComponent()
    {
        base.LoadComponent();
        rbSpider = GetComponent<Rigidbody2D>();
        groundDetection = transform.Find("GroundDetection");
        wallDetection = transform.Find("WallDetection");
        targetDetection = transform.Find("PlayerDetection");
        animSpider = GetComponent<Animator>();
    }
    private void Update()
    {
        CheckIsWall();
        CheckDetectionTarget();
        /*if (isDetectionTarget)
        {
            FollowPlayer();
            speedEnermy = 0f;
            speedFollow = 7f;
        }
        else
        {
            Enermy_Patrol();
            speedEnermy = 5f;
            speedFollow = 0f;
        }*/

    }

    private void FixedUpdate()
    {
        Enermy_Patrol();
    }


    // ============================================= Enermy Follow Player ===========================================
    private void FollowPlayer()
    {
        
    }

    // ============================================= Enermy Patrol ==================================================
    private void Enermy_Patrol()
    {

        if (groundInfo.collider == true && checkCollisionWall==false)
        {
            rbSpider.velocity = new Vector2(-speedEnermy, rbSpider.velocity.y);
            animSpider.SetInteger("State", 0);
        }
        MoveInGround();
        MoveInPlatform();
    }
    private void MoveInPlatform()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, DistanceRaycast);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                animSpider.SetInteger("State", 1);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                animSpider.SetInteger("State", 1);
                movingRight = true;
            }
        }
        
        
    }
    private void MoveInGround()
    {
        if (checkCollisionWall == true)
        {
            if (movingRightInWall == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                animSpider.SetInteger("State", 1);
                movingRightInWall = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                animSpider.SetInteger("State", 1);
                movingRightInWall = true;
            }
        }
        
    }
    private void CheckIsWall()
    {
        checkCollisionWall = Physics2D.OverlapCircle(wallDetection.position, radius, whatIsWall);
    }

    private void CheckDetectionTarget()
    {
        isDetectionTarget = Physics2D.OverlapCircle(targetDetection.position, radiusDetection, whatIsTarget);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(wallDetection.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(targetDetection.position, radiusDetection);
    }
}
