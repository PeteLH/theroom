using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuHandler : MonoBehaviour {

    public Camera fpsCam;
    public Camera menuCam;
    public Canvas HUD;
    public Canvas MainMenu;
    public Canvas tutorial;
    public GameObject player;
    public GameObject inventoryController;
    public AudioSource MainMenuMusic;
    public AudioClip UiClick;
    public AudioClip GameStartSting;
    bool hasSeenTut = false;

    // Use this for initialization
    void Start ()
    {
        fpsCam = GameObject.Find("FPSController").GetComponentInChildren < Camera > ();
        //menuCam = GameObject.Find("MainMenuCam").GetComponentInChildren<Camera>();

        fpsCam.enabled = false;
        menuCam.enabled = true;
        menuCam.fieldOfView = 60;
        HUD.enabled = false;
        MainMenu.enabled = true;
        inventoryController.GetComponent<Inventory>().onMainMenu = true;
        tutorial.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	if (hasSeenTut == false & Input.GetKeyDown("e") & tutorial.enabled == true)
        {
            StartGame();
        }
	}
    public void showTut()
    {
        MainMenu.enabled = false;
        tutorial.enabled = true;
    }

    public void StartGame()
    {
        tutorial.enabled = false;
        menuCam.enabled = false;
        fpsCam.enabled = true;

        HUD.enabled = true;

        player.GetComponent<FirstPersonController>().enabled = true;

        lockCursor();
        inventoryController.GetComponent<Inventory>().onMainMenu = false;
        inventoryController.GetComponent<Inventory>().lockbuttons();
        onGameStartSting();
    }

    public void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OverButtonClick()
    {
        MainMenuMusic.PlayOneShot(UiClick, 1f);
    }

    public void onGameStartSting()
    {
        MainMenuMusic.PlayOneShot(GameStartSting, 1f);
        //MainMenuMusic.mute = true;
    }
}
