using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsManagement : MonoBehaviour
{
    public Rigidbody2D rbObject;
    public GameObject wayPoints;
    public List<Transform> listWayPoint;
    public Vector2 targetPos;
    [Range(0f, 10f)]
    public float speedPlatform;
    [Range(0f, 10f)]
    public float waitDuration;
    public int speedMutiplier;
    public int indexPoint;
    public int direction;
    public int countPoint;


    protected virtual void Awake()
    {
        speedMutiplier = 1;
        LoadObJectMove();
        // Find the number of loaded child gameobjects saved to listWayPoint
        for (int i = 0; i < wayPoints.gameObject.transform.childCount; i++)
        {
            listWayPoint.Add(wayPoints.gameObject.transform.GetChild(i));
        }
    }

    protected virtual void LoadObJectMove() { }

    protected virtual void Start()
    {
        indexPoint = 0;
        targetPos = listWayPoint[indexPoint].position;
        countPoint = listWayPoint.Count-1;
    }

    protected virtual void FixedUpdate()
    {
        if (rbObject != null)
        {
            Moving();
        }
    }
    protected virtual void Moving()
    {
        /*transform.position = Vector2.MoveTowards(transform.position, targetPos, speedMutiplier * speedPlatform * Time.fixedDeltaTime);
        *//*Vector2 newPos = transform.position;*//*
        rbObject.MovePosition(transform.position);*/
        rbObject.MovePosition(Vector2.MoveTowards(transform.position, targetPos, speedMutiplier * speedPlatform * Time.fixedDeltaTime));
        Vector2 newPos = transform.position;
        if (newPos == targetPos)
        {
            MoveNextPoint();
        }
    }

    protected virtual void MoveNextPoint()
    {
        if (indexPoint == countPoint)
        {
            direction = -1;
        }
        else if(indexPoint == 0)
        {
            direction = 1;
        }
        indexPoint += direction;
        targetPos = listWayPoint[indexPoint].position;
        StartCoroutine(WaitNextPoint());
    }
    IEnumerator WaitNextPoint()
    {
        speedMutiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMutiplier = 1;
    }

}
