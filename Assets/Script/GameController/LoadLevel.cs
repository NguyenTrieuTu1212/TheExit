using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [Range(0f, 10f)] public float timeWaitToLoadLevel;
    [SerializeField] private GameObject gameController;
    public Animator animLoadLevel;
    public string nameLevel;
    


    private void Awake()
    {
        gameController = GameObject.Find("GameController");
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(LoadNextLevel());
            gameController.SetActive(true);
        }
    }

    public void EventForButton()
    {
        StartCoroutine(LoadNextLevel());
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
        // Ð?i cho ð?n khi scene m?i hoàn thành load
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        animLoadLevel.SetTrigger("Start");
    }
}
