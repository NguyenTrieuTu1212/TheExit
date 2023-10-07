using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneTest : MonoBehaviour
{
    public string sceneName;
    public void OnClickNewGame()
    {
        DataPersistanceManagement.intance.NewGame();
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("New Game");
    }


    public void OnClickContinueGame()
    {
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("Continue Game");
    }
}
