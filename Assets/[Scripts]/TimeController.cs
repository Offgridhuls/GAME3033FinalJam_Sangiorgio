using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isTimeSlowed;
    public float slowedTime;

    public float slowedTimeDuration;

    public Text slowedTimeText;

    void Start()
    {
        slowedTimeDuration = 10f;
        //Debug.Log(Time.fixedDeltaTime);
    }
    public void OnSlowTime(InputValue value)
    {
        isTimeSlowed = value.isPressed;
    }
    // Update is called once per frame
    void Update()
    {
        slowedTimeText.text = slowedTimeDuration.ToString();
        //Debug.Log(Time.fixedDeltaTime);
       
        if(isTimeSlowed)
        {
            slowedTimeDuration -= Time.deltaTime;
            if (slowedTimeDuration < 0)
                slowedTimeDuration = 0;

            if (slowedTimeDuration > 0)
            {
                Time.timeScale = slowedTime;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
            }
        }
        else
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            //Time.fixedDeltaTime = 1.0f;
        }
    }
}
