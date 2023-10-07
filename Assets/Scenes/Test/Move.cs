using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour,IDataPersistance
{
    public Transform Square;
    [Range(0f, 10f)] public float speed;
    public Vector3 v3;

    private void Awake()
    {
        Square = GetComponent<Transform>();
    }

    public void LoadGame(GameData data)
    {
        this.transform.position = data.vector3Obj;
    }

    public void SaveGame(ref GameData data)
    {
        data.vector3Obj = this.transform.position;
    }

    private void Update()
    {
        Moving();
    }
    private void Moving()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(v3 * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(-v3 * Time.deltaTime);
        }
    }

    
}
