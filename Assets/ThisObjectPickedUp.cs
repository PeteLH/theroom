using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThisObjectPickedUp : MonoBehaviour {

    public GameObject Inventory;

    public void pickedup()
    {
        Inventory.GetComponent<Inventory>().pickupItem(gameObject.GetComponent<Image>());    
    }
}
