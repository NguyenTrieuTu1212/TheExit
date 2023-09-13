using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationExit : MonoBehaviour
{
    [SerializeField] private DisplayPanel windownExitDisplay;
    [SerializeField] private DisplayPanel inventoryDisplay;
    [SerializeField] private GameObject gameController;

    private void Awake()
    {
        windownExitDisplay.Hide();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(windownExitDisplay.isActiveAndEnabled == false)
            {
                if (inventoryDisplay.isActiveAndEnabled) inventoryDisplay.Hide();
                gameController.SetActive(true);
                windownExitDisplay.Show();
            }
            else
            {
                gameController.SetActive(false);
                windownExitDisplay.Hide();
            }
        }
    }
}
