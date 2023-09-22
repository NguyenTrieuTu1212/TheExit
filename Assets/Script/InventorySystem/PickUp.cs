using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private InventoryManagerment inventoryManagerment;
    [SerializeField] private Animator animatorPickup;
    public GameObject objectPrefabs;

    private string currentState;
    const string ANIM_IDLE= "Idle";
    const string ANIM_PICK_UP = "PickUp";


    private void Awake()
    {
        currentState = ANIM_IDLE;
        inventoryManagerment = GameObject.Find("InventoryManagerment").GetComponent<InventoryManagerment>();     
        
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeState(ANIM_PICK_UP);
            for (int i = 0; i < inventoryManagerment.listSlots.Count; i++)
            {
                if (inventoryManagerment.isFull[i] == false)
                {
                    Instantiate(objectPrefabs, inventoryManagerment.listSlots[i].transform, false);

                    Destroy(gameObject);
                    inventoryManagerment.isFull[i] = true;
                    break;
                }
            }
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeState(ANIM_IDLE);
        }
    }

    private void ChangeState(string newState)
    {
        if (currentState == newState) return;
        currentState = newState;
        animatorPickup.Play(newState);
    }
   
}
