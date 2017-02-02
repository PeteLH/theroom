using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClueSetup
{
    public string name;
    public int cluesRequired;
}

[System.Serializable]
public class doorInfo
{
    public string name;
    public GameObject door;
}

public class Cluemanager : MonoBehaviour
{
    public RoomController roomcontroller;
    public ClueSetup[] ClueBuilder;
    public doorInfo[] doorArray;
    public GameObject triggerArray;
    public int noOfCluesCollected;
    public string lastRoom;
    public string lastClue;


    bool roomOneIsDone = false;

    public void FoundClue (string currentRoom, string clueFound)
    {
        noOfCluesCollected++;
        lastRoom = currentRoom;
        lastClue = clueFound;

        if (noOfCluesCollected == 2)
        {
            roomOneIsDone = true;
        }
    }

    public void CoridoorTrigger (GameObject triggerCollided)
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

        if (lastRoom == "Room 1")
        {
            if (roomOneIsDone == true)
            {
                roomcontroller.ClearRooms();
            }
        }
    }
}
