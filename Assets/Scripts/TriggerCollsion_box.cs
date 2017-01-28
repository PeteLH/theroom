using UnityEngine;
using System.Collections;

public class TriggerCollsion_box : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("poopoo");
        }
    }
}
