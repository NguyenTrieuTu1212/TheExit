using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDownItem : MonoBehaviour,IDropHandler
{
    ItemDrag itemDrag;

    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        GameObject droppedItemBlur = eventData.pointerDrag;
        itemDrag = droppedItemBlur.GetComponent<ItemDrag>();
        if(itemDrag.id == 1)
        {
            itemDrag.tranformParentAfterDrag = transform;
            itemDrag.itemImage.transform.position = transform.position;
        }
    }
}
