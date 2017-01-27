using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] roomPresets;

    void Start()
    {
        for (var i = 0; i < spawnPoints.Length; i++)
        {
            Instantiate(roomPresets[0], spawnPoints[i].position, spawnPoints[i].rotation);
        }
    }

    public void ClearRooms()
    {

    }
}

//Transform item in spawnPoints[]