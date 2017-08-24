using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class alarmClock : MonoBehaviour
{
    public bool isErratic;
    public bool isBackwards;
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
        if (isErratic ==  true)
        {
            erretciBehaviour();
            return;
        }

        if (isBackwards == false)
        {
            time += Time.deltaTime;
        }
        else
        {
            time -= Time.deltaTime;
        }

        secsNo = Mathf.FloorToInt(time);

        if (isBackwards == false)
        {
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
        }
        else
        {
            if (time <= 0)
            {
                minsNo--;
                time = 60;

                if (minsNo <= 0)
                {
                    hoursNo--;
                    minsNo = 60;

                    if (hoursNo <= 0)
                    {
                        hoursNo = 24;
                    }
                }
            }
        }

        setToString();
    }

    void erretciBehaviour()
    {
        secsNo = Random.Range(0, 60);
        minsNo = Random.Range(0, 60);
        hoursNo = Random.Range(0, 24);
        setToString();
    }

    void setToString()
    {
        if (secsNo < 10)
        {
            seconds.text = "0" + secsNo.ToString();
        }
        else
        {
            seconds.text = secsNo.ToString();
        }

        if (minsNo < 10)
        {
            mins.text = "0" + minsNo.ToString();
        }
        else
        {
            mins.text = minsNo.ToString();
        }

        if (hoursNo < 10)
        {
            hours.text = "0" + hoursNo.ToString();
        }
        else
        {
            hours.text = hoursNo.ToString();
        }
    }
}