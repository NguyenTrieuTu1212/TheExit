using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScence : MonoBehaviour
{
    [Range(0f, 10f)] public float timeWaitToLoadLevel;
    [SerializeField] private GameObject gameController;
    [SerializeField]private Animator animLoadLevel;
    public string nameScence;
    private int currentIndexScenes;


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
        LoadSceneAsync(nameScence);
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
