using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject prefabObject;
    [SerializeField] private GameObject slot;

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(prefabObject, slot.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
