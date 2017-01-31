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

    public void FoundClue (string currentRoom, string clueFound)
    {
        noOfCluesCollected++;
        lastRoom = currentRoom;
        lastClue = clueFound;
    }

    bool roomOneIsDone = false;

    public void CoridoorTrigger (GameObject triggerCollided)
    {
        if (lastRoom == "Room 1")
        {
            if (roomOneIsDone == false)
            {
                doorArray[1].door.GetComponent<ObjectData>().forceCloseDoor();
                doorArray[1].door.GetComponent<ObjectData>().LockDoor();
                roomOneIsDone = true;
            }

            roomcontroller.ClearRooms();
        }

        if (triggerCollided.gameObject.name == "Room1 Trigger")
        {
            
        }
    }
}
