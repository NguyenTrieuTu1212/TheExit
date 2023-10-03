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
        
        try
        {
            string JsonData = "";
            if (File.Exists(fullPath))
            {
                
                using(FileStream fs = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader sr = new StreamReader(fs))
                    {
                        JsonData = sr.ReadToEnd();
                    }
                }
            }
            loadData = JsonUtility.FromJson<GameData>(JsonData);
        }
        catch(Exception e)
        {
            
        }
        return loadData;
    }

    public void WriteFile(GameData data)
    {
        string fullPath =Path.Combine(dataDirPath,dataFileName);

        try
        {
            // Create direction
            Directory.CreateDirectory(Path.GetFileName(fullPath));

            // Convert Data to Json 
            string dataStore = JsonUtility.ToJson(data);

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
           
        }



    }
}
