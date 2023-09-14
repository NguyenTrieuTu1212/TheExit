using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationExit : MonoBehaviour
{
    [SerializeField] private DisplayPanel windownExitDisplay;
    [SerializeField] private DisplayPanel inventoryDisplay;
    [SerializeField] private GameObject inventoryCanvas;

    private void Awake()
    {
        windownExitDisplay.Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            inventoryDisplay.Hide();
            inventoryCanvas.SetActive(false);
            windownExitDisplay.Show();
            /*if(windownExitDisplay.isActiveAndEnabled == false)
            {
                inventoryDisplay.Hide();
                inventoryCanvas.SetActive(false);
                windownExitDisplay.Show();
            }
            else
            {
                inventoryCanvas.SetActive(true);
                windownExitDisplay.Hide();
            }*/
        }
    }
}
