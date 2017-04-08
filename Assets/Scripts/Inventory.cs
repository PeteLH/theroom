using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour {

    public Canvas inventory;
    public Canvas HUD;
    public GameObject Gamestuff;
    public GameObject menuController;
    public GameObject clueManager;
    public bool onMainMenu = true;
    public GameObject[] unlockedClues;
    public Scrollbar vertScroll;
    public bool isOnInv;
    public ToggleGroup unlockedTogs;
    public ToggleGroup lockedTogs;
    public Text clueName;
    public Animator InvnetoryHolderForAnim;
    public int[] inventorySlots;

    public bool pickingUpItem = false;

    void Start ()
    {
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

        if (pickingUpItem == true)
        {
            unlockedClues[0].transform.position = Input.mousePosition;
        }
    }

    public void addItemToInventory(int clueNumber)
    {
        int i;
        for (i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i] == 0)
            {
                inventorySlots[i] = clueNumber;
                unlockedClues[clueNumber].GetComponent<Image>().overrideSprite = clueManager.GetComponent<Cluemanager>().ClueBuilder[clueNumber].objectIcon;
                unlockedClues[clueNumber].GetComponent<Image>().enabled = true;
                return;
            }
        }
    }

    public void pickupItem()
    {
        Debug.Log("pickup");
        pickingUpItem = true;
    }

    public void currentlyOver(GameObject objectOver)
    {
        Debug.Log("over " + objectOver);
    }

    public void dropItem()
    {
        Debug.Log("drop!");
        pickingUpItem = false;
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