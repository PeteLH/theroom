using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{
    public BoxCollider room1Trigger;
    public BoxCollider room2Trigger;
    public BoxCollider room3Trigger;
    public BoxCollider room4Trigger;

    public Transform[] spawnPoints;
    public GameObject[] roomPresets;
    public List<GameObject> currentRooms = new List<GameObject>();

    void Start()
    {
        for (var i = 0; i < spawnPoints.Length; i++)
        {
            //currentRooms.Add();
            //(Instantiate(roomPresets[0], spawnPoints[i].position, spawnPoints[i].rotation));
            
        }
    }

    void OnCollisionEnter (Collision room1Trigger)
    {

    }

    public void ClearRooms()
    {

    }
}

//Transform item in spawnPoints[]