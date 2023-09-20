using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private InventoryManagerment inventoryManagerment;
    [SerializeField] private Animator animatorPickUp;
    public GameObject objectPrefabs;

    

    private void Awake()
    {
        inventoryManagerment = GameObject.Find("InventoryManagerment").GetComponent<InventoryManagerment>();
        
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animatorPickUp.SetBool("Pick", true);
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
            animatorPickUp.SetBool("Pick", false);
        }
    }
}
