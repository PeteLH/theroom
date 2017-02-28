using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Canvas inventory;

	// Use this for initialization
	void Start ()
    {
        inventory.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("i"))
        {
            if (inventory.enabled == true)
            {
                inventory.enabled = false;
            }
            else
            {
                inventory.enabled = true;
            }
        }
    }
}
