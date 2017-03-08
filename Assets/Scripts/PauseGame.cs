using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class PauseGame : MonoBehaviour {

    GameObject fpsController;
    GameObject fpsCharacter;
    public GameObject Inventory;
    public Canvas HUD;
    public Canvas EscMenu;
    public GameObject menuController;

    public bool isOnEscMenu;
    public int paused; //if this is 1 we are paused, if this is 0 we are unpaused.

    // Use this for initialization
    void Start ()
    {
        fpsController = GameObject.Find("FPSController");
        fpsCharacter = GameObject.Find("FirstPersonCharacter");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Inventory.GetComponent<Inventory>().inventory.enabled == false)
            {
                if (paused == 0)
                {
                    isOnEscMenu = true;
                    pause();
                }
                else if (paused == 1)
                {
                    isOnEscMenu = false;
                    unpause();
                }

                toggleEscMenu();
            }
        }
    }

    public void pause()
    {
        Time.timeScale = 0;
        Debug.Log("game paused");
        fpsController.GetComponent<FirstPersonController>().enabled = false;
        fpsCharacter.GetComponent<BlurOptimized>().enabled = true;
        paused = 1;
    }

    public void unpause()
    {
        Time.timeScale = 1;
        Debug.Log("game live");
        fpsController.GetComponent<FirstPersonController>().enabled = true;
        fpsCharacter.GetComponent<BlurOptimized>().enabled = false;
        paused = 0;
    }

    public void toggleEscMenu()
    {
        if (isOnEscMenu == false)
        {
            EscMenu.enabled = false;
            menuController.GetComponent<MenuHandler>().lockCursor();
            HUD.enabled = true;
        }
        else if (isOnEscMenu == true)
        {
            Debug.Log("on esc menu");
            EscMenu.enabled = true;
            menuController.GetComponent<MenuHandler>().unlockCursor();
            HUD.enabled = false;
        }
    }
}