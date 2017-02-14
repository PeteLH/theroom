using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuHandler : MonoBehaviour {

    public Camera fpsCam;
    public Camera menuCam;
    public Canvas HUD;
    public Canvas MainMenu;
    public GameObject player;

    CursorLockMode inGame;

    // Use this for initialization
    void Start ()
    {
        fpsCam = GameObject.Find("FPSController").GetComponentInChildren < Camera > ();
        menuCam = GameObject.Find("MainMenuCam").GetComponentInChildren<Camera>();

        menuCam.enabled = true;
        fpsCam.enabled = false;
        HUD.enabled = false;
        MainMenu.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame()
    {
        menuCam.enabled = false;
        fpsCam.enabled = true;

        HUD.enabled = true;
        MainMenu.enabled = false;

        Cursor.visible = (CursorLockMode.Locked == inGame);

        player.GetComponent<FirstPersonController>().enabled = true;
    }
}
