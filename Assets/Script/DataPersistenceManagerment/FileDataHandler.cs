using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileDataHandler{

    string dataDirPath="";
    string dataFileName = "";
    public FileDataHandler(string DataDirPath,string DataFileName)
    {
        this.dataDirPath = DataDirPath;
        this.dataFileName = DataFileName;
    }

    public GameData ReadFile()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadData = null;
        if (File.Exists(fullPath))
        {
            string dataJson = "";
            try
            {
                using(FileStream fs = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader sr = new StreamReader(fs))
                    {
                        dataJson = sr.ReadToEnd();
                    }
                }
                loadData = JsonUtility.FromJson<GameData>(dataJson);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
            
        }
        return loadData;
    }

    public void WriteFile(GameData data)
    {
        string fullPath =Path.Combine(dataDirPath,dataFileName);

        try
        {
            // Create direction
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // Convert Data to Json 
            string dataStore = JsonUtility.ToJson(data,true);

            using(FileStream fs = new FileStream(fullPath, FileMode.OpenOrCreate))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(dataStore);
                }
            }

        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }


    }
}
