using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IconButImageSwap : MonoBehaviour {

    public Sprite Regular;
    public Sprite Over;
    public Sprite Selected;

    public void toggle()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            gameObject.GetComponent<Image>().sprite = Selected;
        }
        else if (gameObject.GetComponent<Toggle>().isOn == false)
        {
            gameObject.GetComponent<Image>().sprite = Regular;
        }
    }

    public void iconOver()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            gameObject.GetComponent<Image>().sprite = Selected;
        }
        else if (gameObject.GetComponent<Toggle>().isOn == false)
        {
            gameObject.GetComponent<Image>().sprite = Over;
        }
    }

    public void iconExit()
    {
        if (gameObject.GetComponent<Toggle>().isOn == true)
        {
            gameObject.GetComponent<Image>().sprite = Selected;
        }
        else if (gameObject.GetComponent<Toggle>().isOn == false)
        {
            gameObject.GetComponent<Image>().sprite = Regular;
        }
    }

}
