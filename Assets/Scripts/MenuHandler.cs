using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using MorePPEffects;

public class MenuHandler : MonoBehaviour {

    public Camera fpsCam;
    public Camera menuCam;
    public Canvas HUD;
    public Canvas MainMenu;
    public Canvas tutorial;
    public GameObject player;
    public GameObject inventoryController;
    public AudioSource MainMenuMusic;
    public AudioSource sting;
    public AudioClip UiClick;
    public AudioClip GameStartSting;
    public Animator prologueAnimator;
    public Text prologueText;
    public GameObject playerNameEntry;

    public Canvas prologue;

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
            startPrologue();
        }

        if (Input.GetMouseButtonDown(0) & onPrologue == true)
        {
            advancePeologue();
        }
    }
    public void showTut()
    {
        MainMenu.enabled = false;
        tutorial.enabled = true;
        onGameStartSting();
    }

    bool onPrologue = false;
    public void startPrologue()
    {
        onPrologue = true;
        MainMenuMusic.mute = true;
        prologue.enabled = true;
        prologueAnimator.SetTrigger("FadeIn");
        prologueText.text = "Whatever you do, do not open your eyes.";
    }

    public void disableTutSCreen()
    {
        tutorial.enabled = false;
    }

    public int prologueStage;
    public string playerName;
    public void advancePeologue()
    {
        switch (prologueStage)
        {
            case 0:
                prologueText.text = "What is your name?";
                playerNameEntry.SetActive(true);
                prologueStage++;
                break;

            case 1:
                if(playerNameEntry.GetComponent<InputField>().text != "")
                {
                    playerName = playerNameEntry.GetComponent<InputField>().text;
                    playerNameEntry.SetActive(false);
                    prologueText.text = "You strayed from the straight path " + playerName + ", and now are lost in this dark wood.";
                    prologueStage++;
                }
                break;

            case 2:
                prologueText.text = "I cannt guide you. But will restore your vision.";
                prologueStage++;
                break;

            case 3:
                prologueText.text = playerName + " look for any clue that will lead you away from here.";
                prologueStage++;
                break;

            case 4:
                prologueText.text = "Or it will find you...";
                prologueStage++;
                break;

            case 5:
                prologueText.text = "";
                StartGame();
                break;
        }
    }

    public void StartGame()
    {
        prologue.enabled = false;
        onPrologue = false;
        menuCam.enabled = false;
        fpsCam.enabled = true;
        HUD.enabled = true;

        player.GetComponent<FirstPersonController>().enabled = true;

        lockCursor();
        inventoryController.GetComponent<Inventory>().onMainMenu = false;
        inventoryController.GetComponent<Inventory>().lockbuttons();
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
        sting.PlayOneShot(GameStartSting, 1f);
    }
}
