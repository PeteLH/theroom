using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItsemSets
{
    public string name;
    public GameObject itemToSpawn;
    public Vector3 spawnPos;
    public Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
}


public class RoomController : MonoBehaviour
{
    public BoxCollider room1Trigger;
    public BoxCollider room2Trigger;
    public BoxCollider room3Trigger;
    public BoxCollider room4Trigger;

    public Transform[] spawnPoints;
    public ItsemSets[] roomPresets;
    public List<Object> currentRooms = new List<Object>();

    public int currentRoom;

    void Start()
    {
        spawnInEveryRoom(0);
        spawnInEveryRoom(1);
    }

    public void spawnInEveryRoom(int itemFromSets)
    {
        for (var i = 0; i < spawnPoints.Length; i++)
        {
            var NewItem = GameObject.Instantiate(roomPresets[itemFromSets].itemToSpawn);
            NewItem.transform.parent = GameObject.Find(spawnPoints[i].name).transform;
            NewItem.transform.localPosition = roomPresets[itemFromSets].spawnPos;
            NewItem.transform.localRotation = roomPresets[itemFromSets].spawnRot;
            currentRooms.Add(NewItem);
        }
    }

    public void ClearRooms(string triggerHit) //clears every item
    {
        foreach (Object room in currentRooms)
        {
            Destroy(room);
        }
    }
}