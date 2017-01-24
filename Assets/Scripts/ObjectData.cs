using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectData : MonoBehaviour {
    
    public string ObjectName;
    [TextArea(3, 10)]
    public string ObjectDescription;

    public bool isUseable;
    public bool isTeleportDoor;
    public bool isLightSwitch;
    public bool isAnimated;

    public AudioSource onUseAudioSource;
    public AudioClip[] onUseClipsToPlay;
    int AudioClipCounter;

    public Animator ObjectToAnimate;
    public enum SpcifyAnimation { BedsideDrawer, WardobeDoor, DeskDoor };
    public SpcifyAnimation AnimType;
    public bool isCloased;

    public Light[] SwitchLights;
    public Renderer rendererToSwitchMat;
    public Material[] lightsOnMats;
    public Material[] lightsOffMats;
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

                    if (rendererToSwitchMat != null)
                    {
                        rendererToSwitchMat.sharedMaterials = lightsOffMats;
                    }
                }
            }
            else if (isLightsOn == false)
            {
                foreach (Light lightVar in SwitchLights)
                {
                    lightVar.enabled = true;
                    isLightsOn = true;

                    if (rendererToSwitchMat != null)
                    {
                        rendererToSwitchMat.sharedMaterials = lightsOnMats;
                    }
               }
            }

            playAudio();
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

            switch(AnimType)
            {
                case SpcifyAnimation.BedsideDrawer:

                    if (isCloased == false)
                    {
                        PassOpenCloseTrigger("Close");

                        isCloased = true;
                    }
                    else if ((isCloased == true))
                    {
                        PassOpenCloseTrigger("Open");

                        isCloased = false;
                    }
                    break;

                case SpcifyAnimation.WardobeDoor:

                    if (isCloased == false)
                    {
                        PassOpenCloseTrigger("Close");

                        isCloased = true;
                    }
                    else if ((isCloased == true))
                    {
                        PassOpenCloseTrigger("Open");

                        isCloased = false;
                    }
                    break;

                case SpcifyAnimation.DeskDoor:

                    if (isCloased == false)
                    {
                        PassOpenCloseTrigger("Close");

                        isCloased = true;
                    }
                    else if ((isCloased == true))
                    {
                        PassOpenCloseTrigger("Open");

                        isCloased = false;
                    }
                    break;
            }
        }
    }

    public void GoHere()
    {
        GameObject tempPlayer = GameObject.Find("FPSController");
        tempPlayer.transform.position = teleportTarget.transform.position;
        player.GetComponent<InteractableCheck>().AddToRoomNumber();
    }

    public void PassOpenCloseTrigger (string direction)
    {
        ObjectToAnimate.SetTrigger(direction);
    }
    
    public void playAudio()
    {
        if (onUseClipsToPlay.Length != 0)
        {
            onUseAudioSource.PlayOneShot(onUseClipsToPlay[AudioClipCounter], 1f);

            AudioClipCounter++;
            if (AudioClipCounter == onUseClipsToPlay.Length)
            {
                AudioClipCounter = 0;
            }
        }
    }
}
