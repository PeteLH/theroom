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
    public List<Object> currentRooms = new List<Object>();

    public int currentRoom;

    void Start()
    {
        for (var i = 0; i < spawnPoints.Length; i++)
        {
            Object thisObject = Instantiate(roomPresets[0], spawnPoints[i].position, spawnPoints[i].rotation);
            currentRooms.Add(thisObject);
        }
    }

    public void ClearRooms(string triggerHit)
    {
        foreach (Object room in currentRooms)
        {
            Destroy(room);
        }
    }
}