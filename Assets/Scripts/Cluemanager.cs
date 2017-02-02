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

    public int scene0Summary;

    public void FoundClue (string currentScene, string clueFound)
    {

    }

    public void CoridoorTrigger (GameObject triggerCollided)
    {
        DoorOpenAndLock (triggerCollided);
    }

    void checkCluesInScene0() //check what clues have been collected in the initial scene
    {
        foreach (ClueSetup clue in ClueBuilder)
        {
            if (clue.sceneNumber == 0 & clue.isCollected == true)
            {
                if (clue.name == "Torch")
                {
                    scene0Summary = 1;
                }

                if (clue.name == "Note")
                {
                    scene0Summary = 2; //what if player doesn't collect anything? How do I handle that in a loop?
                }
            }
        }
    }

    void DoorOpenAndLock(GameObject triggerCollided)
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
