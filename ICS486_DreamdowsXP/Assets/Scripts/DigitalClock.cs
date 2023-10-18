using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // used to import text mesh pro package
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    public TextMeshProUGUI clock;
    // int theHour;
    // int theMinute;
    // TimeSpan theTimeOfDay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // DateTime is put in Update function, so the time will calculate in real time
    void Update()
    {
        // gets the current (local) time
        // theHour = DateTime.Now.Hour;
        // theMinute = DateTime.Now.Minute;
        // theTimeOfDay = DateTime.Now.TimeOfDay;
        
        // h means the hour value without a leading 0
        // mm means the minute value with the leading 0
        // tt represents AM or PM

        // need ToString() or else compiler won't recognize the time as something to be displayed on screen
        clock.text = DateTime.Now.ToString("h:mm tt");


        //word.text = theHour.ToString() + ":" + theMinute.ToString() + " " + theTimeOfDay.ToString();
    }
}
