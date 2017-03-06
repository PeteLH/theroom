using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Canvas inventory;
    public Canvas HUD;
    public GameObject Gamestuff;
    public GameObject menuController;
    public bool onMainMenu = true;
    public Button[] unlockedClues;
    public Image[] lockedClues;
    public Scrollbar vertScroll;
    public bool isOnInv;

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
        foreach (Button clue in unlockedClues)
        {
            clue.image.enabled = false;
            clue.interactable = false;
        }
    }

    public void UnlockClue(int clueNumber)
    {
        unlockedClues[clueNumber].image.enabled = true;
        unlockedClues[clueNumber].interactable = true;
        lockedClues[clueNumber].enabled = false;
    }
}
