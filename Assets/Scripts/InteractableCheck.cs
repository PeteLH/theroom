using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractableCheck : MonoBehaviour {

    public float rayDistance;
    public Text ObjectLookingAtText;
    public Text ObjectClickOnText;
    public Image crosshair;
    public Image objectLine;
    RaycastHit hit; //mouse over
    RaycastHit hit1; //mouse click
    public Text TutText;
    AudioSource playerAudio;
    public AudioClip objectNameUi;
    public AudioClip objectInfoUi;
    public AudioClip objectClearUi;
    public AudioClip trochClick;
    public int roomNumber;
    public Image blackScreen;

    bool TriggerOnceLookAtAudio = false;
    bool triggeroncestopLooingat = true;

    GameObject playerController;
    GameObject audioboy;

    bool isFlashlightOn = false;
    public Light flashlight;

    void Start()
    {
        playerController = GameObject.Find("FPSController");
        playerAudio = playerController.GetComponent<AudioSource>();
        objectLine.enabled = false;
        audioboy = GameObject.Find("AudioBoy");
    }

    RaycastHit cache;

    void Update ()
    {
        //mouse over interactable
        Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        if (Physics.Raycast(ray, out hit, rayDistance))

            if (hit.transform.tag == "Interactable")
            {
                crosshair.color = new Color32(0, 255, 1, 30);
                if (cache.collider != null & cache.collider != hit.collider)
                {
                    TriggerOnceLookAtAudio = false;
                }
                cache = hit;
                ObjectsName();
            }

        if (hit.collider == null || hit.collider.tag != "Interactable")
        {
            ClearText();
            crosshair.color = new Color32(255, 255, 255, 30);
        }

        if (hit1.collider != null)
        {
            if (hit.collider != hit1.collider)
            {
                ObjectClickOnText.text = "";
                objectLine.enabled = false;
            }
        }

        //click on interactable
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray1 = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            //Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

            if (Physics.Raycast(ray1, out hit1, rayDistance))

                if (hit1.transform.tag == "Interactable")
                {
                    if (hit1.collider.gameObject.GetComponent<ObjectData>().isUseable == false)
                    {
                        objectDescription();
                        objectLine.enabled = true;
                    }

                    if (hit1.collider.gameObject.GetComponent<ObjectData>().isUseable == true)
                    {
                        if (hit1.collider != null & hit.collider != null)
                        {
                            if (hit.collider == hit1.collider)
                            {
                                hit1.collider.gameObject.GetComponent<ObjectData>().use();
                            }
                        }
                    }

                    if (TutText.enabled == true)
                    {
                        TutText.enabled = false;
                    }

                }
            }

        if (Input.GetMouseButtonDown(1))
        {
            if (isFlashlightOn == true)
            {
                flashlight.enabled = false;
                isFlashlightOn = false;
                playerAudio.PlayOneShot(trochClick, 0.5f);
            }
            else if (isFlashlightOn == false)
            {
                flashlight.enabled = true;
                isFlashlightOn = true;
                playerAudio.PlayOneShot(trochClick, 0.5f);
            }
        }

        }

        

    public void ObjectsName()
    {
        ObjectLookingAtText.text = hit.collider.gameObject.GetComponent<ObjectData>().ObjectName;
        if (TriggerOnceLookAtAudio == false)
        {
            TriggerOnceLookAtAudio = true;
            playerAudio.PlayOneShot(objectNameUi, 0.75f);
        }
    }

    public void objectDescription()
    {
        ObjectClickOnText.text = hit.collider.gameObject.GetComponent<ObjectData>().ObjectDescription;
        triggeroncestopLooingat = false;
        playerAudio.PlayOneShot(objectInfoUi, 0.75f);
    }

    public void ClearText()
    {
        ObjectLookingAtText.text = "";
        ObjectClickOnText.text = "";
        objectLine.enabled = false;
        TriggerOnceLookAtAudio = false;
        if (triggeroncestopLooingat == false)
        {
            triggeroncestopLooingat = true;
            playerAudio.PlayOneShot(objectClearUi, 0.75f);
        }
    }

    public void AddToRoomNumber()
    {
        roomNumber++;

        blackScreen.GetComponent<Image>().enabled = true;
        StartCoroutine(DIsableBlackScreen());
        playerController.GetComponent<FirstPersonController>().enabled = false;

        switch (roomNumber)
        {
            case 0:
                break;
            case 1:
                audioboy.transform.GetChild(0).GetComponent<AudioSource>().mute = true;
                audioboy.transform.GetChild(1).GetComponent<AudioSource>().mute = false;
                break;
            case 2:
                audioboy.transform.GetChild(2).GetComponent<AudioSource>().mute = false;
                audioboy.transform.GetChild(1).GetComponent<AudioSource>().mute = true;
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }

        if (roomNumber != 2)
        {
            audioboy.transform.GetChild(2).GetComponent<AudioSource>().mute = true;
        }
    }

    IEnumerator DIsableBlackScreen()
    {
        yield return new WaitForSeconds(1.5f);
        blackScreen.GetComponent<Image>().enabled = false;
        playerController.GetComponent<FirstPersonController>().enabled = true;
    }
}
