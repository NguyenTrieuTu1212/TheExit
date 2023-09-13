using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadContinueGame : MonoBehaviour
{
    private int indexContinueScenes;
    public void ContinueGame()
    {
        indexContinueScenes = PlayerPrefs.GetInt("SaveScenes");
        Debug.Log("Scenes" + indexContinueScenes);
        SceneManager.LoadSceneAsync(indexContinueScenes);
    }
}
