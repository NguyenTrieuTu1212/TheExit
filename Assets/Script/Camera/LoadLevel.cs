using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [Range(0f, 10f)] public float timeWaitToLoadLevel;
    public Animator animLoadLevel;
    public string nameLevel;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        animLoadLevel.SetTrigger("End");
        yield return new WaitForSeconds(timeWaitToLoadLevel);
        LoadSceneAsync(nameLevel);
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        // �?i cho �?n khi scene m?i ho�n th�nh load
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        animLoadLevel.SetTrigger("Start");
    }
}
