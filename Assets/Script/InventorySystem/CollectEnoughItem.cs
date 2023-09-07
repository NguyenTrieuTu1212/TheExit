using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEnoughItem : MonoBehaviour
{
    public GameObject item;

    private void Awake()
    {
        item = GameObject.Find("Items_Hiding");
    }


    private void Update()
    {
        if (item != null)
        {
            CollectEnoughItems();
        }
    }

    public bool CollectEnoughItems()
    {
        for(int i = 0; i < item.transform.childCount; i++)
        {
            if (item.transform.GetChild(i).childCount == 0) return false;
        }
        return true;
    }
}
