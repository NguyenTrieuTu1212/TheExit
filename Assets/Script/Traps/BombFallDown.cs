using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombFallDown : MonoBehaviour
{
    [SerializeField] GameObject fallingBomb;
    [SerializeField] Rigidbody2D rbBomb;
    public Vector3 originalPosition;
    public bool isFalling;

    [Range(0f, 10f)] public float timeRespawn;
    private void Awake()
    {
        rbBomb = GameObject.Find("Bomb").GetComponent<Rigidbody2D>();
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (isFalling && fallingBomb.transform.position.y < originalPosition.y)
        {
            isFalling = false;
            StartCoroutine(RespawnAfterDelay());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isFalling)
            {
                isFalling = true;
                rbBomb.gravityScale = 1f;
            }
        }
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(timeRespawn);
        SpawnFallingObject();
    }

    private void SpawnFallingObject()
    {
        if (fallingBomb != null)
        {
            Destroy(fallingBomb);
        }

        fallingBomb = Instantiate(fallingBomb, originalPosition, Quaternion.identity);
        rbBomb.gravityScale = 0f;
    }



}
