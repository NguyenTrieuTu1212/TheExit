using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerment : MonoBehaviour
{
    
    [SerializeField] private DisplayPanel inventoryDisplay;
    [SerializeField] private GameObject Slots;
    
    public List<GameObject> listSlots;
    public List<bool> isFull;
    private int countSlots;
    
    
    private void Awake()
    {

        // Find the gameobject named "Slots" so you can load its child objects into the listSlots
        Slots = GameObject.Find("Slots");

        // Load child gameobject named "Slots" in listSlots
        for (int i = 0; i < Slots.transform.childCount; i++)
            listSlots.Add(Slots.transform.GetChild(i).gameObject);

        // Mark all Slots in the list of Slots as empty
        for (int i = 0; i < listSlots.Count; i++)
            isFull.Add(false);
        inventoryDisplay.Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryDisplay.isActiveAndEnabled== false)
            {
                inventoryDisplay.Show();
            }
            else
            {
                inventoryDisplay.Hide();
            }
        }
    }
}
