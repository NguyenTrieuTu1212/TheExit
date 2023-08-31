using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallUp : MoveObject
{
    [SerializeField] Rigidbody2D rbPlayer;
    [SerializeField] GameObject Wall;
    [SerializeField] bool isWallOpen;
  
    [Range(0f, 10f)]
    public float speedWallUp;
    [Range(0f,10f)]
    public float timeDestroyWall;

    private void Awake()
    {
        Wall = GameObject.FindWithTag("Wall");
    }
    protected override void MoveFlatforms()
    {
        if (isWallOpen)
        {
            Wall.transform.Translate(Vector3.up *speedWallUp * Time.deltaTime);
            timeDestroyWall -= Time.fixedDeltaTime;
            if(timeDestroyWall < 0f)
            {
                Destroy(gameObject); 
            }
        }     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player")) isWallOpen= true;
    }
}
