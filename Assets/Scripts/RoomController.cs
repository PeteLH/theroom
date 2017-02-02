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

    public Transform[] spawnPoints; // array of the spawn points, 1 - 4
    public ItsemSets[] roomPresets; // array of the class above listing each spawnable item set and it's spawn location info
    public List<Object> currentRooms = new List<Object>(); // A dynamic list that keeps track of what item sets we have spawned in. Can be used to mass clear 

    public int currentRoom;

    void Start()
    {
        SpawnInRoomOne(0);
        SpawnInRoomOne(1);
        SpawnInRoomOne(4);
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

    public void ClearRooms() //clears every item
    {
        foreach (Object room in currentRooms)
        {
            Destroy(room);
        }
    }

    public void SpawnInRoomOne(int itemFromSets)
    {
        var NewItem = GameObject.Instantiate(roomPresets[itemFromSets].itemToSpawn);
        NewItem.transform.parent = GameObject.Find(spawnPoints[0].name).transform;
        NewItem.transform.localPosition = roomPresets[itemFromSets].spawnPos;
        NewItem.transform.localRotation = roomPresets[itemFromSets].spawnRot;
        currentRooms.Add(NewItem);
    }

    public void SpawnInRoomTwo(int itemFromSets)
    {
        var NewItem = GameObject.Instantiate(roomPresets[itemFromSets].itemToSpawn);
        NewItem.transform.parent = GameObject.Find(spawnPoints[1].name).transform;
        NewItem.transform.localPosition = roomPresets[itemFromSets].spawnPos;
        NewItem.transform.localRotation = roomPresets[itemFromSets].spawnRot;
        currentRooms.Add(NewItem);
    }

    public void SpawnInRoomThree(int itemFromSets)
    {
        var NewItem = GameObject.Instantiate(roomPresets[itemFromSets].itemToSpawn);
        NewItem.transform.parent = GameObject.Find(spawnPoints[2].name).transform;
        NewItem.transform.localPosition = roomPresets[itemFromSets].spawnPos;
        NewItem.transform.localRotation = roomPresets[itemFromSets].spawnRot;
        currentRooms.Add(NewItem);
    }

    public void SpawnInRoomFour(int itemFromSets)
    {
        var NewItem = GameObject.Instantiate(roomPresets[itemFromSets].itemToSpawn);
        NewItem.transform.parent = GameObject.Find(spawnPoints[3].name).transform;
        NewItem.transform.localPosition = roomPresets[itemFromSets].spawnPos;
        NewItem.transform.localRotation = roomPresets[itemFromSets].spawnRot;
        currentRooms.Add(NewItem);
    }
}