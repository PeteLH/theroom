using UnityEngine;
using System.Collections;

public class CamBob : MonoBehaviour
{
    public Transform camTransform;
    Vector3 originalPos;
    Vector3 direction;
    private float time;
    public float directionSwitchFrequency;
    public float speed;

    float poo;

    void Awake()
    {
        if (camTransform == null) //if camera transofrm is not null 
        {
            camTransform = GetComponent(typeof(Transform)) as Transform; //get it"!
            originalPos = camTransform.localPosition;
        }
    }

    void Start()
    {
        SwitchDIrection();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= directionSwitchFrequency)
        {
            time = 0.0f;

            SwitchDIrection();
        }

        camTransform.Rotate (direction * Time.deltaTime * speed);
    }

    int counter = 0;
    void SwitchDIrection()
    {
        counter++;
        if (counter == 5)
        {
            counter = 0;
            direction = new Vector3 (23, 112, 4); //need to fix this, get cam to focus on orhinal position 
        }
        else
        {
            switch (Random.Range(0, 3))
            {
                case 0:
                    direction = Vector3.right;
                    break;
                case 1:
                    direction = Vector3.left;
                    break;
                case 2:
                    direction = Vector3.up;
                    break;
                case 3:
                    direction = Vector3.down;
                    break;
            }
        }
    }
}

//// Transform of the camera to shake. Grabs the gameObject's transform
//// if null.
//public Transform camTransform;

////if true the cam will shake forever
//public bool shakeForever;

//// How long the object should shake for.
//public float shakeDuration = 0f;

//// Amplitude of the shake. A larger value shakes the camera harder.
//public float shakeAmount = 0.7f;
//public float decreaseFactor = 1.0f;


//Vector3 originalPos;

//private float time;

//private float journeyLength;
//private float startTime;
//Vector3 endTarget;

//[Header("used vars")]
//public float speed;
//public float BobFrequency;

//void Awake()
//{
//    if (camTransform == null) //if camera transofrm is not null 
//    {
//        camTransform = GetComponent(typeof(Transform)) as Transform; //get it"!
//        originalPos = camTransform.localPosition;
//    }
//}

//void Start()
//{
//    BobMove();
//    startTime = Time.time;
//}

//void Update()
//{
//    time += Time.deltaTime * speed;

//    float distCovered = (Time.time - startTime) * speed;
//    float fracJourney = distCovered / journeyLength;
//    camTransform.localPosition = Vector3.Lerp(camTransform.position, endTarget, time);

//    if (time > 0.8f)
//    {
//        BobMove();
//    }

//    //if (time >= BobFrequency)
//    //{
//    //    time = 0.0f;

//    //    BobMove();
//    //}
//}

//void BobMove()
//{
//    time = 0;
//    journeyLength = Vector3.Distance(camTransform.position, endTarget);
//    endTarget = new Vector3(camTransform.localPosition.x + Random.Range(-0.1f, 0.1f), camTransform.localPosition.y + Random.Range(-0.1f, 0.1f), camTransform.localPosition.z + Random.Range(-0.1f, 0.1f));
//}

//void OnEnable() - camTransform.position + Random.insideUnitSphere * shakeAmount;
//{

//}

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