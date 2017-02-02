using UnityEngine;
using System.Collections;

public class TriggerCollision : MonoBehaviour {

    public GameObject RoomController;
    public GameObject clueManager;
    GameObject thisTrigger;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "RoomTrigger")
        {
            clueManager.GetComponent<Cluemanager>().CoridoorTrigger ( col.gameObject );
            Debug.Log(col.gameObject.name);
        }
    }
}