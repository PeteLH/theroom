using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.ImageEffects;

public class PauseGame : MonoBehaviour {

    GameObject fpsController;
    GameObject fpsCharacter;

	// Use this for initialization
	void Start ()
    {
        fpsController = GameObject.Find("FPSController");
        fpsCharacter = GameObject.Find("FirstPersonCharacter");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pause();
        }
    }

    public void pause()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Debug.Log("game live");
            fpsController.GetComponent<FirstPersonController>().enabled = true;
            fpsCharacter.GetComponent<BlurOptimized>().enabled = false;
        }
        else
        {
            Time.timeScale =0;
            Debug.Log("game paused");
            fpsController.GetComponent<FirstPersonController>().enabled = false;
            fpsCharacter.GetComponent<BlurOptimized>().enabled = true;
        }
    }
}
