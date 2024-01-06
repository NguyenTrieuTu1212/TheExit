using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MainPlayer/*,IDataPersistance*/
{
    
    public float Move_Speed = 8.0f;
    private bool IsFacingRight = true;
    private float Horizal;

    
    public Rigidbody2D rbDynamicPlatform;
    public bool isOnDynamicPlatform;


    /*public void LoadGame(GameData data)
    {
        transform.parent.position = data.postionSpawnPlayer;
    }

    public void SaveGame(ref GameData data)
    {
        data.postionSpawnPlayer = transform.parent.position;
    }*/

    private void FixedUpdate()
    {
        Moving();
    }
    private void Moving()
    {
        Horizal = InputManegement.Instance.GetHorizontal();
        animator.SetFloat("Speed",Mathf.Abs(Horizal));
        if (isOnDynamicPlatform)
        {
            //Player moving in dynamic platform
            rb.velocity = new Vector2((Horizal * Move_Speed) + rbDynamicPlatform.velocity.x, rb.velocity.y);
        }
        else
        {
            //Player moving in static platform
            rb.velocity = new Vector2(Horizal * Move_Speed, rb.velocity.y);
        }
        if (Horizal > 0 && !IsFacingRight) Flip();
        if (Horizal < 0 && IsFacingRight) Flip();
    }
    private void Flip()
    {
        Vector3 CurrentScale = gameObject.transform.parent.localScale;
        CurrentScale.x *= -1;
        gameObject.transform.parent.localScale = CurrentScale;
        IsFacingRight = !IsFacingRight;
    }

   
}
