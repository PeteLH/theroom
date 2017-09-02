using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour
{

    public bool isFlickering = true;
    public int FlickerRate = 8;
    public float speed = 15;
    Light lightToFlick;

    // Use this for initialization
    void Start()
    {
        lightToFlick = gameObject.GetComponent<Light>();
    }

    float targetFlickerValue;
    void Update()
    {
        if (isFlickering == true)
        {
            if (Random.Range(0, 100) < FlickerRate) //a random chance
            {
                FlickerRate = Random.Range(4, 16);
                speed = Random.Range(5, 10);
                targetFlickerValue = Random.Range (0, 2.2f);
            }
        }
        lightToFlick.intensity = Mathf.Lerp(lightToFlick.intensity, targetFlickerValue, speed * Time.deltaTime);
    }
}
