using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDownItem : MonoBehaviour, IDropHandler
{
    public ItemDrag itemDrag;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        itemDrag = dropped.GetComponent<ItemDrag>();  
        if(itemDrag.id == 1)
        {
            itemDrag.tranformParentAfterDrag = transform;
        }
    }
}
