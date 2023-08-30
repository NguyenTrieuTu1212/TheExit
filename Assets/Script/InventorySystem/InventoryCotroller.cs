using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCotroller : MonoBehaviour
{
    public bool isOpen = false;
    public InventoryPage inventoryPage;

    private void Awake()
    {
        inventoryPage.Hide();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryPage.isActiveAndEnabled== false)
            {
                inventoryPage.Show();
            }
            else
            {
                inventoryPage.Hide();
            }
        }
    }
}
