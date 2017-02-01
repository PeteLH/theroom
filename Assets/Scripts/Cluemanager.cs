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
        if (lastRoom == "Room 1") ;
        {
            if (triggerCollided.name == "Room1 Trigger")
            {
                doorArray[1].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
                doorArray[1].door.GetComponentInChildren<ObjectData>().LockDoor();
                doorArray[7].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
            }

            if (roomOneIsDone == true)
            {
                roomcontroller.ClearRooms();
            }
        }

        if (lastRoom == "Room 1")
        {
            doorArray[3].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[3].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[1].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }

        if (lastRoom == "Room 1")
        {
            doorArray[5].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[5].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[3].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }

        if (lastRoom == "Room 1")
        {
            doorArray[7].door.GetComponentInChildren<ObjectData>().forceCloseDoor();
            doorArray[7].door.GetComponentInChildren<ObjectData>().LockDoor();
            doorArray[5].door.GetComponentInChildren<ObjectData>().UnlockLockDoor();
        }
    }
}
