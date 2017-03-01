using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClueSetup
{
    [Header("Clue name")]
    public string name;
    [Header("Clues available")]
    public bool isCollected;
    [Header("Scene this appears in")]
    public int sceneNumber;
}

[System.Serializable]
public class doorInfo
{
    public string name;
    public GameObject door;
}

public class Cluemanager : MonoBehaviour
{
    [Header ("Link to roomcontroller")]
    public RoomController roomcontroller;

    [Header("Clue Builder")]
    public ClueSetup[] ClueBuilder;
    public doorInfo[] doorArray;
    public int totalCluesCollected;

    public bool hasTorch = false;
    public bool hasNote= false;

    public GameObject inventoryController;

     public void FoundClue (string clueFound) //fired from object data, when that object is flagged a clue
    {
        switch (clueFound)
        {
            case "Flashlight":
                ClueBuilder[0].isCollected = true;
                TakeIntAndUnlock(0);
                break;

            case "Note":
                ClueBuilder[1].isCollected = true;
                TakeIntAndUnlock(1);
                break;
            case "DeadBody":
                ClueBuilder[2].isCollected = true;
                TakeIntAndUnlock(2);
                break;

            case "UniWelcomePack":
                ClueBuilder[3].isCollected = true;
                TakeIntAndUnlock(3);
                break;
        }
    }

    public void TakeIntAndUnlock(int clueNumber)
    {
        inventoryController.GetComponent<Inventory>().UnlockClue(clueNumber);
    }

    public void CoridoorTrigger (GameObject triggerCollided) //fire from Trigger Collision which is attached to the player
    {
        DoorOpenAndLock (triggerCollided); //locks the door behind the player and opens the previously locked door
        roomcontroller.RoomClear(); //clears all rooms of items and resets the current items list


        // depending on which trigger is hit populate the next room 
        if (triggerCollided.name == "Room1 Trigger")
        {
            Scene0SpawnModifier(1);
        }
        else if (triggerCollided.name == "Room2 Trigger")
        {
            Scene0SpawnModifier(2);
        }
        else if (triggerCollided.name == "Room3 Trigger")
        {
            Scene0SpawnModifier(3);
        }
        else if (triggerCollided.name == "Room4 Trigger")
        {
            Scene0SpawnModifier(0);
        }
    }
    // 0 - Torch
    // 1 - Note
    void Scene0SpawnModifier(int room) //spawn scene 1 items depending on what clues have been found
    {
        if (ClueBuilder[0].isCollected == false & ClueBuilder[1].isCollected == false) //Need to fix this, if first 2 clues are collected hw do we trigger someting different when 3rd and 4th are too? 
        {
            roomcontroller.RoomSpawner(room, 0);
        }
        else if (ClueBuilder[0].isCollected == true & ClueBuilder[1].isCollected == false)
        {
            roomcontroller.RoomSpawner(room, 1);
        }
        else if (ClueBuilder[0].isCollected == false & ClueBuilder[1].isCollected == true)
        {
            roomcontroller.RoomSpawner(room, 2);
        }
        else if (ClueBuilder[0].isCollected == true & ClueBuilder[1].isCollected == true)
        {
            roomcontroller.RoomSpawner(room, 3);
        }
        else if (ClueBuilder[2].isCollected == true & ClueBuilder[3].isCollected == true)
        {
            roomcontroller.RoomSpawner(room, 4);
        }
    }

    void DoorOpenAndLock(GameObject triggerCollided) // door lock settings after each room
    {
        if (triggerCollided.name == "Room1 Trigger")
        {
            doorArray[1].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[1].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[0].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[0].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
            doorArray[7].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }

        if (triggerCollided.name == "Room2 Trigger")
        {
            doorArray[3].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[3].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[2].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[2].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
            doorArray[1].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }

        if (triggerCollided.name == "Room3 Trigger")
        {
            doorArray[5].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[5].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[4].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[4].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
            doorArray[3].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }

        if (triggerCollided.name == "Room4 Trigger")
        {
            doorArray[7].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[7].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[6].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[6].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
            doorArray[5].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }
    }
}
