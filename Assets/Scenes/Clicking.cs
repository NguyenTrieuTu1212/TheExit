using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicking : MonoBehaviour,IDataPersistance
{
    public int countClick=0;
    public int clickCountSave=0;
    public Text txtTextCount;

    
    public void LoadGame(GameData data)
    {
        countClick = data.countClicked;
    }

    public void SaveGame(ref GameData data)
    {
        data.countClicked = countClick;
    }

    public void OnClick()
    {
        countClick++;
        displayCountClick();
    }

    public void displayCountClick()
    {
        txtTextCount.text = "Clicked " + countClick;
    }

    
}
