using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//[ExecuteAlways]
public class TimeController : MonoBehaviour
{
    [SerializeField]
    public float timeMultiplier;

    [SerializeField]
    private Material Skyboxy;

    [SerializeField]
    private float startHour;
    //add text gui for time;

    public DateTime currentTime;

    [SerializeField]
    private Light sunLight;

    [SerializeField]
    private float sunriseHour;

    public Lightingpreset DayPreset;
    public Lightingpreset NightPreset;

    [SerializeField]
    private float sunsetHour;
    [SerializeField]
    private TimeSpan sunriseTime;
    [SerializeField]
    private TimeSpan sunsetTime;

    public TextMeshProUGUI hourDisplay;
    public static TimeController Instance;

    public int Day = 1;
    public DateTime date;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now.Date +TimeSpan.FromHours(startHour);
        date = DateTime.Now.Date;
        sunriseTime = TimeSpan.FromHours(sunriseHour);
        sunsetTime = TimeSpan.FromHours(sunsetHour);
    }
    private void Awake()
    {
        Instance = this;
    }

    private void CheckDay()
    {
        if (currentTime.Date != date.Date)
        {
            date = currentTime;
            Day++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimeOfDay();
        RotateSun();
        CheckDay();
    }

    private void UpdateTimeOfDay()
    {
        currentTime = currentTime.AddSeconds(timeMultiplier * Time.deltaTime);

        //show in UI
        hourDisplay.text = currentTime.ToString("HH:mm");
    }
    public void RotateSun()
    {
        float sunlightRotation;
        if (currentTime.TimeOfDay > sunriseTime && currentTime.TimeOfDay < sunsetTime)
        {
            TimeSpan sunriseToSunsetDuration = CalculateTimeDiff(sunriseTime, sunsetTime);
            TimeSpan timeSinceSunrise = CalculateTimeDiff(sunriseTime, currentTime.TimeOfDay);

            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunsetDuration.TotalMinutes;

            sunlightRotation = Mathf.Lerp(0, 180, (float)percentage);
            float skycolor = Mathf.Lerp(0, 0.5f, (float)percentage);

            RenderSettings.ambientLight = DayPreset.ambientColor.Evaluate(skycolor);
            Skyboxy.SetColor("_SkyTint", DayPreset.directionalColor.Evaluate(skycolor));
            sunLight.color = DayPreset.directionalColor.Evaluate(skycolor);


        }
        else
        {
            TimeSpan sunsetToSunriseDuration = CalculateTimeDiff(sunsetTime,sunriseTime);
            TimeSpan timeSinceSunset = CalculateTimeDiff(sunsetTime,currentTime.TimeOfDay);

            double percentage = timeSinceSunset.TotalMinutes/ sunsetToSunriseDuration.TotalMinutes;

            sunlightRotation= Mathf.Lerp(180,360, (float)percentage);
            float skycolor = Mathf.Lerp(0.5f, 1, (float)percentage);
            RenderSettings.ambientLight = DayPreset.ambientColor.Evaluate(skycolor);
            Skyboxy.SetColor("_SkyTint", DayPreset.directionalColor.Evaluate(skycolor));
            sunLight.color = DayPreset.directionalColor.Evaluate(skycolor);
        }
        sunLight.transform.rotation = Quaternion.AngleAxis(sunlightRotation, new Vector3(1,0,0));
        
    }
    public TimeSpan CalculateTimeDiff(TimeSpan fromTime, TimeSpan toTime)
    {
        TimeSpan diff = toTime - fromTime;
        if (diff.TotalSeconds < 0)
        {
            diff += TimeSpan.FromHours(24);
        }
        return diff;
    }
}