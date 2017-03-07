using UnityEngine;
using System.Collections;

public class SpashScript : MonoBehaviour {

    public GameObject mainMenu;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void destroyThisObject()
    {
        mainMenu.SetActive(true);
        Destroy(gameObject);
    }
}
