using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Canvas inventory;
    public Canvas HUD;
    public GameObject Gamestuff;
    public GameObject menuController;
    public bool onMainMenu = true;
    public GameObject[] unlockedClues;
    public Image[] lockedClues;
    public Scrollbar vertScroll;
    public bool isOnInv;
    public ToggleGroup unlockedTogs;
    public ToggleGroup lockedTogs;

    //----- 

    // Use this for initialization
    void Start ()
    {
        inventory.enabled = false;
        vertScroll.value = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("i") & onMainMenu == false & Gamestuff.GetComponent<PauseGame>().isOnEscMenu == false)
        {
            if (inventory.enabled == true)
            {
                inventory.enabled = false;
                Gamestuff.GetComponent<PauseGame>().unpause();
                menuController.GetComponent<MenuHandler>().lockCursor();
                HUD.enabled = true;
                unlockedTogs.SetAllTogglesOff();
                lockedTogs.SetAllTogglesOff();
            }
            else
            {
                inventory.enabled = true;
                Gamestuff.GetComponent<PauseGame>().pause();
                menuController.GetComponent<MenuHandler>().unlockCursor();
                HUD.enabled = false;
            }
        }
    }

    public void lockbuttons()
    {
        foreach (GameObject clue in unlockedClues)
        {
            clue.GetComponent<Image>().enabled = false;
            clue.GetComponent<Toggle>().interactable = false;
        }
    }

    public void UnlockClue(int clueNumber)
    {
        unlockedClues[clueNumber].GetComponent<Image>().enabled = true;
        unlockedClues[clueNumber].GetComponent<Toggle>().interactable = true;
        lockedClues[clueNumber].enabled = false;
    }
}
