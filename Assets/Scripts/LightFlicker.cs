using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{

    public bool isFlickering = true;
    public int FlickerRate;
    Light lightToFlick;

    // Use this for initialization
    void Start()
    {
        lightToFlick = gameObject.GetComponent<Light>();
    }
    
    void Update()
    {
        if (isFlickering == true)
        {
            if (Random.Range(0, 100) < FlickerRate) //a random chance
            {
                lightToFlick.intensity = Random.Range(0, 2.2f);

                //if (lightToFlick.enabled == true) //if the light is on...
                //{
                //    lightToFlick.enabled = false; //turn it off
                //}
                //else
                //{
                //    lightToFlick.enabled = true; //turn it on
                //}
            }
        }
    }
}
