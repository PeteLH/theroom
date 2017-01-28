using UnityEngine;
using System.Collections;

public class TriggerCollision : MonoBehaviour {

    public GameObject RoomController;

    void OnControllerColliderEnter(ControllerColliderHit col)
    {
        if (col.gameObject.tag == "RoomTrigger")
        {
            Debug.Log("poopoo");
            RoomController.GetComponent<RoomController>().ClearRooms(col.gameObject.name);
        }
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "RoomTrigger")
        {
            Debug.Log("poopoo");
            RoomController.GetComponent<RoomController>().ClearRooms(col.gameObject.name);
        }
    }
}