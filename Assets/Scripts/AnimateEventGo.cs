using UnityEngine;
using System.Collections;

public class AnimateEventGo : MonoBehaviour {

    public GameObject objectDataItem;

    public void PlayAudio()
    {
        objectDataItem.GetComponent<ObjectData>().playAudio();
    }
}