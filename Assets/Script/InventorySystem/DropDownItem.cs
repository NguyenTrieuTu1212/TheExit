using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDownItem : MonoBehaviour, IDropHandler
{
    public ItemDrag itemDrag;
    public int itemTarget;
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        itemDrag = dropped.GetComponent<ItemDrag>();  
        if(itemDrag.id == itemTarget)
        {
            itemDrag.tranformParentAfterDrag = transform;
        }
    }
}
