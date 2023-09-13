using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScenes : MonoBehaviour
{
    private int currentIndexScenes;
    public void SaveScene()
    {
        currentIndexScenes = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SaveScenes", currentIndexScenes);
    }
}
