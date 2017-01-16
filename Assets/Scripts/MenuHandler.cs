using UnityEngine;
using System.Collections;

public class MenuHandler : MonoBehaviour {

    public Camera fpsCam;
    public Camera menuCam;

	// Use this for initialization
	void Start ()
    {
        fpsCam = GameObject.Find("FPSController").GetComponentInChildren < Camera > ();
        menuCam = gameObject.GetComponent<Camera>();

        menuCam.enabled = true;
        fpsCam.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
