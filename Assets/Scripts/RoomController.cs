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

[System.Serializable]
public class RoomItemCombinations
{
    public string name;
    public int[] ItemSetCombo;
}

public class RoomController : MonoBehaviour
{
    public BoxCollider room1Trigger;
    public BoxCollider room2Trigger;
    public BoxCollider room3Trigger;
    public BoxCollider room4Trigger;

    public Transform[] spawnPoints; // array of the spawn points, 0 - 3
    public ItsemSets[] spawnItems; // array of the class above listing each spawnable item set and it's spawn location info
    public RoomItemCombinations[] roomSets; //array of ints that represent various item sets
    public List<Object> currentRooms = new List<Object>(); // A dynamic list that keeps track of what item sets we have spawned in. Can be used to mass clear 

    public int currentRoom;

    void Start()
    {
        for (var i = 0; i < roomSets[0].ItemSetCombo.Length; i++)
        {
            ItemSpawner(0, roomSets[0].ItemSetCombo[i]);
        }
    }

    public void spawnInEveryRoom(int itemFromSets)
    {
        for (var i = 0; i < spawnPoints.Length; i++)
        {
            var NewItem = GameObject.Instantiate(spawnItems[itemFromSets].itemToSpawn);
            NewItem.transform.parent = GameObject.Find(spawnPoints[i].name).transform;
            NewItem.transform.localPosition = spawnItems[itemFromSets].spawnPos;
            NewItem.transform.localRotation = spawnItems[itemFromSets].spawnRot;
            currentRooms.Add(NewItem);
        }
    }

    public void ClearRooms() //clears every item
    {
        foreach (Object room in currentRooms)
        {
            Destroy(room);
        }

        currentRooms.Clear();
    }

    public void ItemSpawner(int Room, int itemFromSets)
    {
        var NewItem = GameObject.Instantiate(spawnItems[itemFromSets].itemToSpawn);
        NewItem.transform.parent = GameObject.Find(spawnPoints[Room].name).transform;
        NewItem.transform.localPosition = spawnItems[itemFromSets].spawnPos;
        NewItem.transform.localRotation = spawnItems[itemFromSets].spawnRot;
        currentRooms.Add(NewItem);
    }
}