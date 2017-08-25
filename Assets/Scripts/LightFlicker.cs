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
            }
        }
    }
}
