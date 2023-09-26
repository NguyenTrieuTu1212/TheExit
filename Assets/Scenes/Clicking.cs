using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicking : MonoBehaviour,IDataPersistence
{
    public int countClick=0;
    public Text txtTextCount;


    public void LoadData(GameData data)
    {
        this.countClick = data.clickCount;
    }

    public void SaveData(ref GameData data)
    {
        data.clickCount = this.countClick;
    }

    private void Update()
    {
        if(countClick < 100)
        {
            countClick++;
            displayCountClick();
        }
    }

    public void displayCountClick()
    {
        txtTextCount.text = "Clicked " + countClick;
    }

    
}
