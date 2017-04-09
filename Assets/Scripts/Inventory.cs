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

        if (pickingUpItem == true)
        {
            unlockedClues[pickedupitemNo].transform.position = Input.mousePosition;
            pickedupItem = unlockedClues[pickedupitemNo].GetComponent<RectTransform>();

            foreach (RectTransform slot in slots)
            {
                if (rectOverlaps(pickedupItem, slot))
                {
                    Debug.Log("over " + slot.name);
                    currentOver = slot;
                }
            }
        }
    }

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

    public void pickupItem(Image Objectpickedup)
    {
        Debug.Log("pickup");
        // for each item in our inventory scan through and find the one we clicked on
        foreach (InventoryItems item in inventorySlots)
        {
            if (Objectpickedup == item.itemIcon)
            {
                pickedupitemNo = item.item;
            }
        }
        pickingUpItem = true;
    }

    public void dropItem()
    {
        Debug.Log("drop!");
        pickingUpItem = false;

        {
            int i;
            for (i = 0; i < slots.Length; i++)
            {
                if (currentOver == slots[i])
                {
                    unlockedClues[pickedupitemNo].transform.position = slots[i].transform.position;
                }
                //else if (currentOver == null)
                //{
                //    foreach (int no in inventorySlots)
                //        if (no == 1)
                //        {
                //            System.Array.IndexOf(inventorySlots, no);
                //            unlockedClues[1].transform.position = slots[System.Array.IndexOf(inventorySlots, no)].GetComponent<Transform>().position;
                //        }
                //}
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