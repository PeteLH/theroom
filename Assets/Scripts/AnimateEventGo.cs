using UnityEngine;
using System.Collections;

public class AnimateEventGo : MonoBehaviour {

    public GameObject objectDataItem;
    public GameObject menuControler;

    public void PlayAudio()
    {
        objectDataItem.GetComponent<ObjectData>().playAudio();
    }

    public void playDoorOpen1()
    {
        objectDataItem.GetComponent<ObjectData>().playDoorOpen1();
    }

    public void playDoorOpen2()
    {
        objectDataItem.GetComponent<ObjectData>().playDoorOpen2();
    }

    public void playDoorClose()
    {
        objectDataItem.GetComponent<ObjectData>().playDoorClose();
    }
    public void ToggleIsAnimating()
    {
        objectDataItem.GetComponent<ObjectData>().toggleIsAnimating();
    }

    public void HideTut()
    {
        menuControler.GetComponent<MenuHandler>().disableTutSCreen();
    }
}