using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManagerment : MonoBehaviour
{
    private GameData gameData;
    private List<IDataPersistence> dataPersistenceLists = new List<IDataPersistence>();
    public static DataPersistenceManagerment instance { get; private set; }

    private void Awake()
    {
        if(instance!=null) return;
        instance = this;
    }


    private void Start()
    {
        this.dataPersistenceLists = FindAllDataPersistence();
        LoadGame();
    }

    private void NewGame()
    {
        this.gameData = new GameData();
    }

    private void LoadGame()
    {
        if(this.gameData == null)
        {
            Debug.Log("Don't have data game");
            NewGame();
        }
        
        foreach (IDataPersistence dataPersistence in dataPersistenceLists)
        {
            dataPersistence.LoadData(gameData);
        }
        Debug.Log("Load: " + gameData.clickCount);
    }


    private void SaveGame()
    {
        foreach (IDataPersistence dataPersistence in dataPersistenceLists)
        {
            dataPersistence.SaveData(ref gameData);
        }
        Debug.Log("Save: " + gameData.clickCount);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistence()
    {
        IEnumerable<IDataPersistence> dataPersistenceList = FindObjectsOfType<MonoBehaviour>().
            OfType<IDataPersistence>();
        return new List<IDataPersistence>(dataPersistenceList);
    }

}
