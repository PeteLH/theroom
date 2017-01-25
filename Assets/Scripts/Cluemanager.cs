using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClueSetup
{
    public string name;
    public ObjectData[] cluesRequired;
    public int noOfCluesCollected;
}

public class Cluemanager : MonoBehaviour
{
    public ClueSetup[] ClueBuilder;

    public void FoundClue (string currentRoom)
    {

    }

}
