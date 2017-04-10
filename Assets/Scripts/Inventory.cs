using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class InventoryItems
{
    public int item = -1;
    public Image itemIcon;
}

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
    public InventoryItems[] inventorySlots;

    public bool pickingUpItem = false;
    public int pickedupitemNo;

    public RectTransform pickedupItem;
    public RectTransform[] slots;
    public RectTransform currentOver;

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
                Gamestuff.GetComponent<PauseGame>().pause();
                menuController.GetComponent<MenuHandler>().unlockCursor();
            }
            else
            {
                animateInventoryOut();
                invIsIn = false;
                Gamestuff.GetComponent<PauseGame>().unpause();
                menuController.GetComponent<MenuHandler>().lockCursor();
            }
        }

        //if the picked up item bool is true...
        if (pickingUpItem == true)
        {
            unlockedClues[pickedupitemNo].transform.position = Input.mousePosition; //the image we use for items collected set to follow mouse cursor
            pickedupItem = unlockedClues[pickedupitemNo].GetComponent<RectTransform>(); //get the rect transform of the object we have picked up for...

            foreach (RectTransform slot in slots) // in the slots array we list all of th UI images for the inevntory slots, here we iterate through these to see if we're overlapping any empty slots
            {
                if (rectOverlaps(pickedupItem, slot)) //if we are overlapping
                {
                    Debug.Log("over " + slot.name); //debug log
                    currentOver = slot; //cache the slot we're over
                }
            }
        }
    }

    //this function handles wether we're our rect transforsm are overlapping 
    bool rectOverlaps(RectTransform rectTrans1, RectTransform rectTrans2)
    {
        Rect rect1 = new Rect(rectTrans1.localPosition.x, rectTrans1.localPosition.y, rectTrans1.rect.width, rectTrans1.rect.height);
        Rect rect2 = new Rect(rectTrans2.localPosition.x, rectTrans2.localPosition.y, rectTrans2.rect.width, rectTrans2.rect.height);

        return rect1.Overlaps(rect2);
    }

    public void addItemToInventory(int clueNumber) //add the item of this clue number to the inventory 
    {
        int i;
        for (i = 0; i < inventorySlots.Length; i++) //iterate through the inventory slots

        {
            if (inventorySlots[i].item == -1) //if the inventory slot is 0 (empty) 
            {
                inventorySlots[i].item = clueNumber; //store the clue
                unlockedClues[i].GetComponent<Image>().overrideSprite = clueManager.GetComponent<Cluemanager>().ClueBuilder[clueNumber].objectIcon; //set the UI image above that slot to the one of the clue
                unlockedClues[i].GetComponent<Image>().enabled = true; //enable that image

                inventorySlots[i].itemIcon = unlockedClues[i].GetComponent<Image>();
                return; //break out of this fucntion 
            }
        }
    }

    public int PickedupItemSlot; //cache the picked up itmes slot for drop refrence

    public void pickupItem(Image Objectpickedup)
    {
        // for each item in our inventory scan through and find the one we clicked on
        int i;
        for (i = 0; i < inventorySlots.Length; i++)
        {
            if (Objectpickedup == inventorySlots[i].itemIcon) //if the image of the object picked up is the same as the one cached in the inventory array
            {
                pickedupitemNo = inventorySlots[i].item; //record what item we've currently picked up
                pickingUpItem = true; // flag that we have picked up an item
                PickedupItemSlot = i; // cache the slot in the inventory array that we have picked an item up from
                Debug.Log("pickup"); //debug log
                return; //end the function
            }
        }
    }

    public void dropItem()
    {
        Debug.Log("drop!"); //debuglog
        pickingUpItem = false; //set this to false when we drop an item

        int i;
        for (i = 0; i < slots.Length; i++) //go through all our inventory slots
        {
            if (currentOver == slots[i]) //if the slot we are currently over is equal to one of the slots in the array...
            {
                if (inventorySlots[i].item == pickedupitemNo) //slot is the same one as the item was picked up from
                {
                    unlockedClues[pickedupitemNo].transform.position = slots[PickedupItemSlot].transform.position;
                }
                else if (inventorySlots[i].item == -1) //slot is empty
                {
                    unlockedClues[pickedupitemNo].transform.position = slots[i].transform.position; //drop the item into that slot
                    inventorySlots[i].item = pickedupitemNo; //update our inventory array item to be that item number
                    inventorySlots[i].itemIcon = unlockedClues[pickedupitemNo].GetComponent<Image>(); //change the image in the inventory array to be the same as the one we have picked up

                    // here we clear the previous slot
                    inventorySlots[PickedupItemSlot].item = -1;
                    inventorySlots[PickedupItemSlot].itemIcon = null;
                    PickedupItemSlot = -1;
                }
                else if (inventorySlots[i].item != pickedupitemNo && inventorySlots[i].item >= 0) //is not the current slot and is not empty
                {
                    //need to get what's in the slot the item is dropping into and store it
                    // drop the picked up item into this slot
                    //then use the stored data to populate the old slot, doing a switch
                    //bed time...
                }
                    return; //end function
            }
        }
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