using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Canvas inventory;
    public Canvas HUD;
    public GameObject Gamestuff;
    public GameObject menuController;
    public GameObject clueManager;
    public bool onMainMenu = true;
    public GameObject[] unlockedClues;
    public Image[] lockedClues;
    public Scrollbar vertScroll;
    public bool isOnInv;
    public ToggleGroup unlockedTogs;
    public ToggleGroup lockedTogs;
    public Text clueName;
    public Animator InvnetoryHolderForAnim;
    public int[] inventorySlots;

    void Start ()
    {
        //inventory.enabled = false;
        vertScroll.value = 1;

        clueName.text = "";
    }

    bool invIsIn;
	void Update ()
    {
        if (Input.GetKeyDown("i") & onMainMenu == false & Gamestuff.GetComponent<PauseGame>().isOnEscMenu == false)
        {
            if (invIsIn == false)
            {
                animateInventoryIn();
                invIsIn = true;
                //inventory.enabled = true;
                Gamestuff.GetComponent<PauseGame>().pause();
                menuController.GetComponent<MenuHandler>().unlockCursor();
                //HUD.enabled = false;
            }
            else
            {
                animateInventoryOut();
                invIsIn = false;
                //inventory.enabled = false;
                Gamestuff.GetComponent<PauseGame>().unpause();
                menuController.GetComponent<MenuHandler>().lockCursor();
                //HUD.enabled = true;
                //unlockedTogs.SetAllTogglesOff();
                //lockedTogs.SetAllTogglesOff();
                //clueName.text = "";
            }
        }
    }

    //public void lockbuttons()
    //{
    //    foreach (GameObject clue in unlockedClues)
    //    {
    //        clue.GetComponent<Image>().enabled = false;
    //        clue.GetComponent<Toggle>().interactable = false;
    //    }
    //}

    //public void UnlockClue(int clueNumber)
    //{
    //    unlockedClues[clueNumber].GetComponent<Image>().enabled = true;
    //    unlockedClues[clueNumber].GetComponent<Toggle>().interactable = true;
    //    lockedClues[clueNumber].enabled = false;
    //}

    public void addItemToInventory(int clueNumber)
    {
        //inventorySlots[0] = clueNumber;
        //unlockedClues[clueNumber].GetComponent<Image>().enabled = clueManager.GetComponent<Cluemanager>().ClueBuilder[clueNumber].objectIcon;
    }

    public void pickupItem()
    {
        //Cursor.SetCursor(clueManager.GetComponent<Cluemanager>().ClueBuilder[0].objectIcon, 0);
    }

    public void dropItem()
    {
        Debug.Log("drop!");
    }

    public void UpdateClueName(GameObject ClueName)
    {
        clueName.text = ClueName.name;
    }

    public void animateInventoryIn()
    {
        InvnetoryHolderForAnim.SetTrigger("SlideIn");
    }

    public void animateInventoryOut()
    {
        InvnetoryHolderForAnim.SetTrigger("SlideOut");
    }
}