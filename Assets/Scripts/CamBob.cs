using UnityEngine;
using System.Collections;

public class CamBob : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    //if true the cam will shake forever
    public bool shakeForever;

    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    float x;
    float y;
    float z;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }

        x = originalPos.x + Random.insideUnitSphere.x * shakeAmount;
        y = originalPos.y + Random.insideUnitSphere.y * shakeAmount;
        z = originalPos.z + Random.insideUnitSphere.z * shakeAmount;
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        camTransform.localPosition = new Vector3(Mathf.Lerp(originalPos.x, x, shakeAmount), Mathf.Lerp(originalPos.y, y, shakeAmount), Mathf.Lerp(originalPos.z, z, shakeAmount));

        //if (shakeDuration > 0)
        //{
        //    camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

        //    shakeDuration -= Time.deltaTime * decreaseFactor;
        //}
        //else
        //{
        //    shakeDuration = 0f;
        //    camTransform.localPosition = originalPos;
        //}
    }
}