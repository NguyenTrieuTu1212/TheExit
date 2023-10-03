using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManagement : MonoBehaviour
{
    public GameData gameData;
    [SerializeField] string fileNameSaveData;
    public FileDataHandler fileDataHandler;
    public DataPersistanceManagement intance { get; private set; }
    List<IDataPersistance> listDataPersistances = new List<IDataPersistance>();
    


    private void Awake()
    {
        fileDataHandler = new FileDataHandler("F:\\", fileNameSaveData);
        listDataPersistances = FindAllDataPersistance();
       
    }

    private void Start()
    {
        if(intance != null)
        {
            Debug.Log("More than one intance in Game");
        }
        intance = this;
        LoadGame();
    }

    private void NewGame()
    {
        gameData= new GameData();
    }


    private void LoadGame()
    {
        if (gameData == null)
        {
            Debug.Log("Game data not found");
            NewGame();
        }
        foreach (IDataPersistance persistance in listDataPersistances)
        {
            persistance.LoadGame(gameData);
        }
        gameData = fileDataHandler.ReadFile();
        Debug.Log("Data load is: " + gameData.countClicked);
    }

    private void SaveGame()
    {
        
        foreach (IDataPersistance persistance in listDataPersistances)
        {
            persistance.SaveGame(ref gameData);
        }
        fileDataHandler.WriteFile(gameData);
        Debug.Log("Data save is: " + gameData.countClicked);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistance()
    {
        IEnumerable<IDataPersistance> listDataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(listDataPersistances);
    }


}
