using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

[System.Serializable]
public class cluesNeeded
{
    public string name;
    public int maxClues;
}

public class Cluemanager : MonoBehaviour
{
    [Header ("Link to roomcontroller")]
    public RoomController roomcontroller;

    [Header("Clue Builder")]
    public ClueSetup[] ClueBuilder;
    public cluesNeeded[] cluesCollected;
    public doorInfo[] doorArray;

    [SerializeField]
    int clueAmount;

    public GameObject inventoryController;

    public GameObject UnlockCLuePopUp;

     public void FoundClue (int clueFound) //fired from object data, when that object is flagged a clue
    {
        if (ClueBuilder[clueFound].isCollected != true)
        {
            ClueBuilder[clueFound].isCollected = true;
            TakeIntAndUnlock(clueFound);

            clueAmount++;
            ClueFoundPopUp();
        }
    }

    public void TakeIntAndUnlock(int clueFound)
    {
        inventoryController.GetComponent<Inventory>().addItemToInventory(clueFound);
    }

    public void ClueFoundPopUp()
    {
        UnlockCLuePopUp.GetComponent<Animator>().SetTrigger("FadeIn");
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
        //2 - 6 - 8 - 11 - 13 - 16 - /0/ - 18 - 19 - 20 - 22 - 24
        if (clueAmount < 2)
        {
            roomcontroller.RoomSpawner(room, 0);
        }
        else if (clueAmount < 6)
        {
            roomcontroller.RoomSpawner(room, 3);
        }
        else if (clueAmount < 8)
        {
            roomcontroller.RoomSpawner(room, 4);
        }
        else if (clueAmount < 11)
        {
            roomcontroller.RoomSpawner(room, 5);
        }
        else if (clueAmount < 13)
        {
            roomcontroller.RoomSpawner(room, 6);
        }
        else if (clueAmount < 16)
        {
            roomcontroller.RoomSpawner(room, 7);
        }
        else if (clueAmount < 17) // this is the room with no clue (0) - need to have a hidden clue sort of thing?
        {
            roomcontroller.RoomSpawner(room, 8);
        }
        else if (clueAmount < 18)
        {
            roomcontroller.RoomSpawner(room, 9);
        }
        else if (clueAmount < 19)
        {
            roomcontroller.RoomSpawner(room, 10);
        }
        else if (clueAmount < 20)
        {
            roomcontroller.RoomSpawner(room, 11);
        }
        else if (clueAmount < 22)
        {
            roomcontroller.RoomSpawner(room, 12);
        }
        else if (clueAmount < 24)
        {
            roomcontroller.RoomSpawner(room, 13);
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