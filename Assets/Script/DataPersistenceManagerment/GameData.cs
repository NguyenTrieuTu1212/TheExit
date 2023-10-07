using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData 
{
   
    public Vector3 vector3Obj;
    public int count;
    public Vector3 postionSpawnPlayer;
    public GameData()
    {
       this.vector3Obj = new Vector3(0,0,0);
       this.postionSpawnPlayer = new Vector3(0.36f, -93.48f, 0);
       count = 0;
    }
}
