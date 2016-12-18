using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class alarmClock : MonoBehaviour
{

    public Text hours;
    public Text mins;
    public Text seconds;

    public int hoursNo = 23;
    public int minsNo = 59;
    public int secsNo;

    float time;

    // Use this for initialization
    void Start()
    {
        hours.text = hoursNo.ToString();
        mins.text = minsNo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        secsNo = Mathf.FloorToInt(time);

        if (time >= 60)
        {
            minsNo++;
            time = 0;

            if (minsNo >= 60)
            {
                hoursNo++;
                minsNo = 0;

                if (hoursNo >= 24)
                {
                    hoursNo = 0;
                }
            }
        }

        seconds.text = secsNo.ToString();
        mins.text = minsNo.ToString();
        hours.text = hoursNo.ToString();
    }
}
