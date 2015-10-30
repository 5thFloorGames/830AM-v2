using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunningTime : MonoBehaviour {

    public int minutes = 49;
    public int hours = 7;

    public int endMinutes = 30;
    public int endHours = 8;

    public int extraTime = 15;

    float timer = 0;
    float timeElapsingInterval = 1.0f;

    string getOutString = "";

	// Use this for initialization
	void Start () {
        string hourString = "";
        if (endHours < 10)
        {
            hourString += "0";
        }
        hourString += endHours.ToString();

        string minuteString = "";
        if (endMinutes < 10)
        {
            minuteString += "0";
        }
        minuteString += endMinutes.ToString();

        getOutString = hourString + ":" + minuteString;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        timer += Time.deltaTime;

        if (timer > timeElapsingInterval)
        {
            timer = 0;
            minutes++;

            if (minutes >= 60)
            {
                hours++;
            }

            minutes = minutes % 60;
            hours = hours % 24;

            if (hours >= endHours && minutes >= endMinutes)
            {
                extraTime--;
            }
        }

        Text text = GetComponent<Text>();

        string hourString = "";
        if (hours < 10)
        {
            hourString += "0";
        }
        hourString += hours.ToString();

        string minuteString = "";
        if (minutes < 10)
        {
            minuteString += "0";
        }
        minuteString += minutes.ToString();

        text.text = "The time is " + hourString + ":" + minuteString + "\n" + "I have to leave by " + getOutString;

        if (hours >= endHours && minutes >= endMinutes)
        {
            text.text = "Damn, I am late!";
        }

        if (extraTime <= 0)
        {
            GameObject gameControl = GameObject.Find("GameControl");
            ControlGame control = gameControl.GetComponent<ControlGame>();
            control.Reset();
        }

    }
}