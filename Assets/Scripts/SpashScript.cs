using UnityEngine;
using System.Collections;

public class SpashScript : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject mainMenuHandler;
    public bool toggleDestroyDEBUG;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void destroyThisObject()
    {
        if (toggleDestroyDEBUG ==  false)
        {
            mainMenu.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void playMainMenuMusic()
    {
        mainMenuHandler.GetComponent<MenuHandler>().playMainMenuMusic();
    }
}
