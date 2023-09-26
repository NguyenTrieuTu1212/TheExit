using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicking : MonoBehaviour
{
    public Text txtCount;
    private int countClick;

    public void OnClick()
    {
        countClick++;
    }


    public void disPlayCountClick()
    {
        txtCount.text += countClick;
    }
}
