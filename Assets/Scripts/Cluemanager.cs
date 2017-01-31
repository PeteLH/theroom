using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClueSetup
{
    public string name;
    public int cluesRequired;
}

public class Cluemanager : MonoBehaviour
{
    public RoomController roomcontroller;
    public ClueSetup[] ClueBuilder;
    public int noOfCluesCollected;
    public string lastRoom;
    public string lastClue;

    public void FoundClue (string currentRoom, string clueFound)
    {
        noOfCluesCollected++;
        lastRoom = currentRoom;
        lastClue = clueFound;
    }

    public void CoridoorTrigger (string triggerCollided)
    {
        if (lastRoom == "Room 1")
        {
            roomcontroller.ClearRooms();
        }
    }
}
