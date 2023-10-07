using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class DataPersistanceManagement : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] string fileNameSaveData;
    public FileDataHandler fileDataHandler;
    public static DataPersistanceManagement intance { get; private set; }
    List<IDataPersistance> listDataPersistances = new List<IDataPersistance>();



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;  
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Start game");
        listDataPersistances = FindAllDataPersistance();
        LoadGame();
    }



    private void OnSceneUnLoaded(Scene scene)
    {
        Debug.Log("UnLoaded");
        SaveGame();
    }


    private void Awake()
    {
        if (intance != null)
        {
            Debug.Log("More than one intance in Game");
            Destroy(gameObject);
            return;
        }
        intance = this;
        DontDestroyOnLoad(gameObject);
        fileDataHandler = new FileDataHandler("F:\\", fileNameSaveData);
    }

    

    public void NewGame()
    {
        gameData= new GameData();
    }


    private void LoadGame()
    {
        gameData = fileDataHandler.ReadFile();
        if (gameData == null)
        {
            Debug.Log("Game data not found");
            NewGame();
        }
        foreach (IDataPersistance persistance in listDataPersistances)
        {
            persistance.LoadGame(gameData);
        }
        
        Debug.Log("Data load is: " + gameData.postionSpawnPlayer);
    }

    private void SaveGame()
    {
        
        foreach (IDataPersistance persistance in listDataPersistances)
        {
            persistance.SaveGame(ref gameData);
        }
        fileDataHandler.WriteFile(gameData);
        Debug.Log("Data save is: " + gameData.postionSpawnPlayer);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistance()
    {
        /*IEnumerable<IDataPersistance> listDataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(listDataPersistances);*/

        List<IDataPersistance> dataPersistanceList = new List<IDataPersistance>();
        foreach (GameObject gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
            IDataPersistance dataPersistance = gameObject.GetComponent<IDataPersistance>();
            if (dataPersistance != null)
            {
                dataPersistanceList.Add(dataPersistance);
            }
        }
        return dataPersistanceList;
    }



}
