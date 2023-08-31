using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ItemDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform tranformParet;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        tranformParet = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(tranformParet);
    }

    
}
