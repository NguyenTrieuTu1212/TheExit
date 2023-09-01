using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrop : MonoBehaviour, IDropHandler
{
    ItemDrag itemDragAndDrop;


    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        itemDragAndDrop = dropped.GetComponent<ItemDrag>();
        itemDragAndDrop.tranformParentAfterDrag = transform;
    }
}
