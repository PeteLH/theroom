using UnityEngine;
using System.Collections;

public class AnimateEventGo : MonoBehaviour {

    public GameObject objectDataItem;

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
}