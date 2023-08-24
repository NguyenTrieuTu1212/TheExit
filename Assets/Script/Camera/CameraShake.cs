using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    const string CAM_SHAKE = "ShakeCamera";
    [SerializeField] Rigidbody2D rbPlayer;
    [SerializeField] bool isShaking=false;
    [Range(0,10f)]
    public float timeCounter;
    public GameObject cameraObject;
    public Animator camAnim;

    private void Start()
    {
        rbPlayer = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isShaking)
        {
            Shake();
        }
    }

    private void Shake()
    {
        camAnim.enabled = true;
        camAnim.Play(CAM_SHAKE);
        timeCounter -= Time.deltaTime;
        // Freeze posion X contranints in rigibody 2D ==> (make the Player stand still) 
        rbPlayer.constraints = RigidbodyConstraints2D.FreezePositionX;
        if (timeCounter <= 0f)
        {
            // Unfreeze posion X contranints in rigibody 2D ==> (Player moves as usual)
            rbPlayer.constraints &= ~RigidbodyConstraints2D.FreezePositionX;
            rbPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
            camAnim.enabled = false;
            timeCounter = 0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) isShaking = true; 
    }
}
