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
    public GameObject ObjectToAnimate;

    public Light[] SwitchLights;
    public bool isLightsOn;
    public GameObject teleportTarget;

    public GameObject player;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("FPSController").GetComponent<Transform>().GetChild(1).gameObject;
    }

    bool isCloased = false;

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
            if (isCloased == false)
            {
                ObjectToAnimate.GetComponent<Animation>().Play("CloseDrawr");

                isCloased = true;
            }
            else if ((isCloased == true))
            {
                ObjectToAnimate.GetComponent<Animation>().Play("OpenDrawr");

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
}
