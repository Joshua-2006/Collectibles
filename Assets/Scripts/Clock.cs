using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    public int startTime;
    public int time;
    public bool isRunning;
    public TextMeshProUGUI clockDisplay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(0.5f);
        if (isRunning)
        {
            time--;
            UpdateDisplay();
            if (time <= 0)
            {
                TimerDone();
            }
        }
        StartCoroutine(Countdown());
    }
    public void UpdateDisplay()
    {
        clockDisplay.text = time.ToString();
    }
    public void TimerDone()
    {
        isRunning = false;
    }
    public void ChangeTime(int timeToAdd)
    {
        time += timeToAdd;
    }
    public void ToggleTime()
    {
        isRunning = !isRunning;
    }
    public void ResetTime()
    {
        time = startTime;
    }
}
