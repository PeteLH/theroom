using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class ObjectData : MonoBehaviour {

    public string ObjectName;
    [TextArea(3, 10)]
    public string ObjectDescription;

    public bool isUseable;
    public bool isTeleportDoor;
    public bool isLightSwitch;
    public bool isAnimated;
    public Animator ObjectToAnimate;
    bool isCloased = true;

    public Light[] SwitchLights;
    //public Material[] SwitchMaterials; - an array o matterials to toggle
    public bool isLightsOn;
    public GameObject teleportTarget;

    public GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("FPSController").GetComponent<Transform>().GetChild(1).gameObject;
    }

    public void use()
    {
        if (isTeleportDoor == true)
        {
            GoHere();
        }

        if (isLightSwitch == true)
        {
            if (isLightsOn == true)
            {
                foreach (Light lightVar in SwitchLights)
                {
                    lightVar.enabled = false;
                    isLightsOn = false;
                }
            }
            else if (isLightsOn == false)
            {
                foreach (Light lightVar in SwitchLights)
                {
                    lightVar.enabled = true;
                    isLightsOn = true;
                }
            }
        }

        if (isAnimated == true)
        {

            // public gameobject itemToAnimate
            // enum type of object to animate (drawer, door, lightswitch, etc.)
            //
            // depending on the enum set in the inspector...
            // ...call the script that relates to this, for example "DrawerAnimationController" on the "itemToAnimate" gameobject.
            // ^ might be abe to do the above in this script
            // 
            //

            if (isCloased == false)
            {
                drawers("Close");

                isCloased = true;
            }
            else if ((isCloased == true))
            {
                drawers("Open");

                isCloased = false;
            }
        }
    }

    public void GoHere()
    {
        GameObject tempPlayer = GameObject.Find("FPSController");
        tempPlayer.transform.position = teleportTarget.transform.position;
        player.GetComponent<InteractableCheck>().AddToRoomNumber();
    }

    public void drawers (string direction)
    {
        ObjectToAnimate.SetTrigger(direction);
    }
}
