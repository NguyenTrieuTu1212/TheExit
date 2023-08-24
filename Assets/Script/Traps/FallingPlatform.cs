using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rbPlatform;
    [SerializeField] public Collider2D colPlatform;
    [SerializeField] public PlayerDeath playerDeath;
    [Range(0f, 10f)] public float timeDelayFalling;
    private Vector3 originalPosition;

    private void Awake()
    {
        playerDeath = GameObject.Find("Die").GetComponent<PlayerDeath>();
    }
    private void Start()
    {
        originalPosition = transform.position;
        rbPlatform.bodyType = RigidbodyType2D.Kinematic;
    }

    private void Update()
    {
        if (playerDeath.IsDie)
        {
            transform.position = originalPosition;
            rbPlatform.MovePosition(transform.position);
            rbPlatform.bodyType = RigidbodyType2D.Kinematic;
            colPlatform.isTrigger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitFalling());
        }
    }

    IEnumerator WaitFalling()
    {
        yield return new WaitForSeconds(timeDelayFalling);
        rbPlatform.bodyType = RigidbodyType2D.Dynamic;
        colPlatform.isTrigger = true;
 
    }
}
