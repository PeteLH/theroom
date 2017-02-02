﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectData : MonoBehaviour {
    
    public string ObjectName;
    [TextArea(3, 10)]
    public string ObjectDescription;

    public bool isUseable;
    //public bool isTeleportDoor;
    public bool isLightSwitch;
    public bool isAnimated;
    public bool isClue;
    public bool isCollected;
    public string roomNumber;

    public AudioSource onUseAudioSource;
    public AudioClip[] onUseClipsToPlay;
    int AudioClipCounter;

    public Animator ObjectToAnimate;
    public enum SpcifyAnimation { BedsideDrawer, WardobeDoor, DeskDoor, roomDoor };
    public SpcifyAnimation AnimType;
    public bool isClosed;
    public bool isDoorLocked;
    public Collider doorHandle1;
    public Collider doorHandle2;

    public Light[] SwitchLights;
    public Renderer rendererToSwitchMat;
    public Material[] lightsOnMats;
    public Material[] lightsOffMats;
    public bool isLightsOn;
    public GameObject teleportTarget;

    public GameObject player;
    public Cluemanager ClueManager;

    public bool isAnimating = false;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("FPSController").GetComponent<Transform>().GetChild(1).gameObject;
        ClueManager = GameObject.Find("Clue Manager Object").GetComponent<Cluemanager>();

        if (isDoorLocked == true)
        {
            LockDoor();
        }
    }

    public void use()
    {
        if (isClue == true)
        {
            player.GetComponent<InteractableCheck>().objectDescription();
            player.GetComponent<InteractableCheck>().objectLine.enabled = true;
            ClueManager.FoundClue(roomNumber, gameObject.name);
        }

        if (isCollected == true)
        {
            detroyCurrentItem();
        }

        //if (isTeleportDoor == true)
        //{
        //    GoHere();
        //}

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
            if (isDoorLocked != true)
            {

                switch (AnimType)
                {
                    case SpcifyAnimation.BedsideDrawer:

                        if (isClosed == false)
                        {
                            PassOpenCloseTrigger("Close");

                            isClosed = true;
                        }
                        else if ((isClosed == true))
                        {
                            PassOpenCloseTrigger("Open");

                            isClosed = false;
                        }
                        break;

                    case SpcifyAnimation.WardobeDoor:

                        if (isClosed == false)
                        {
                            PassOpenCloseTrigger("Close");

                            isClosed = true;
                        }
                        else if ((isClosed == true))
                        {
                            PassOpenCloseTrigger("Open");

                            isClosed = false;
                        }
                        break;

                    case SpcifyAnimation.DeskDoor:

                        if (isClosed == false)
                        {
                            PassOpenCloseTrigger("Close");

                            isClosed = true;
                        }
                        else if ((isClosed == true))
                        {
                            PassOpenCloseTrigger("Open");

                            isClosed = false;
                        }
                        break;

                    case SpcifyAnimation.roomDoor:

                        if (isAnimating == false)
                        {
                            if (isClosed == false)
                            {
                                PassOpenCloseTrigger("Close");

                                isClosed = true;
                            }
                            else if ((isClosed == true))
                            {
                                PassOpenCloseTrigger("Open");

                                isClosed = false;
                            }
                        }

                        break;
                }
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

    public void playDoorOpen1()
    {
        onUseAudioSource.PlayOneShot(onUseClipsToPlay[0], 1f);
    }

    public void playDoorOpen2()
    {
        onUseAudioSource.PlayOneShot(onUseClipsToPlay[1], 1f);
    }

    public void playDoorClose()
    {
        onUseAudioSource.PlayOneShot(onUseClipsToPlay[2], 1f);
    }

    public void forceCloseDoor()
    {
        if (isClosed != true)
        {
            PassOpenCloseTrigger("Close");
            isClosed = true;
        }
    }

    public void LockDoor()
    {
        isDoorLocked = true;
        ObjectName = "Locked";
    }

    public void UnlockLockDoor()
    {
        isDoorLocked = false;
        ObjectName = "Door";
    }

    public void toggleIsAnimating()
    {
        if (isAnimating == false)
        {
            isAnimating = true;
        }
        else if (isAnimating == true)
        {
            isAnimating = false;
        }
    }

    public void detroyCurrentItem()
    {
        Destroy(gameObject);
        player.GetComponent<InteractableCheck>().hasCollectedFlashlight = true;
    }
}
