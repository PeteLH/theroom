using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour {

    public GameObject menuHandler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HideIntro()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        menuHandler.GetComponent<MenuHandler>().StartGame();
    }
}
