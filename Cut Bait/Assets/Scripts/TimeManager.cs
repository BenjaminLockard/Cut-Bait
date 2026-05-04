using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class TimeManager : MonoBehaviour
{
    public int day;
    
    private float currentTime;
    public TMP_Text timerText;
    public bool ticking;

    public void showGuidesToday()
    {
        MatchGuide[] allGuides = Object.FindObjectsByType<MatchGuide>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (MatchGuide guide in allGuides)
        {
            if (guide.dayShown == day)
            {
                guide.thisPanel.SetActive(true);
            }
        }
    }





    public void resetTime()
    {
        ticking = false;
        currentTime = 360;
        DisplayTime(currentTime);
    }

    public void startTime()
    {
        ticking = true;
    }

    void Start()
    {
        resetTime();
        day = 1;
    }

    void Update()
    {
        if (currentTime <= 0)
        {
            ticking = false;

        } else if (ticking == true) {
            DisplayTime(currentTime);
            currentTime -= Time.deltaTime;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
