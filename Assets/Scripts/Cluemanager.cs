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
    int cluesCollected;
}

public class Cluemanager : MonoBehaviour
{
    [Header ("Link to roomcontroller")]
    public RoomController roomcontroller;

    [Header("Clue Builder")]
    public ClueSetup[] ClueBuilder;
    public cluesNeeded[] cluesCollected;
    public doorInfo[] doorArray;
    int currentRoom;

    [SerializeField]
    int clueAmount;

    //public bool hasTorch = false;
    //public bool hasNote = false;

    public GameObject inventoryController;

    public GameObject UnlockCLuePopUp;

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

            case "Room_2_date":
                ClueBuilder[4].isCollected = true;
                TakeIntAndUnlock(4);
                break;

            case "Room_2_wardrobe":            
                ClueBuilder[5].isCollected = true;
                TakeIntAndUnlock(5);
                break;
        }

        clueAmount++;
        ClueFoundPopUp();
    }

    public void TakeIntAndUnlock(int clueNumber)
    {
        inventoryController.GetComponent<Inventory>().UnlockClue(clueNumber);
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

        //if (ClueBuilder[0].isCollected == false & ClueBuilder[1].isCollected == false) //Need to fix this, if first 2 clues are collected hw do we trigger someting different when 3rd and 4th are too? 
        //{
        //    roomcontroller.RoomSpawner(room, 0);
        //}
        //else if (ClueBuilder[0].isCollected == true & ClueBuilder[1].isCollected == false)
        //{
        //    roomcontroller.RoomSpawner(room, 1);
        //}
        //else if (ClueBuilder[0].isCollected == false & ClueBuilder[1].isCollected == true)
        //{
        //    roomcontroller.RoomSpawner(room, 2);
        //}
        //else if (ClueBuilder[0].isCollected == true & ClueBuilder[1].isCollected == true)
        //{
        //    roomcontroller.RoomSpawner(room, 3);
        //}
        //else if (ClueBuilder[2].isCollected == true & ClueBuilder[3].isCollected == true)
        //{
        //    roomcontroller.RoomSpawner(room, 4);
        //}
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