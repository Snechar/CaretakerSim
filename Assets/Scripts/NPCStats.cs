using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStats : MonoBehaviour
{
    [Range(0f, 100f)]
    public float food;
    public float foodRatePerHour;
    private float actualFoodRate;

    [Range(0f, 100f)]
    public float toilet;
    public float toiletRatePerHour;
    private float actualToiletRate;

    [Range(0f, 100f)]
    public float sleep;
    public float sleepRatePerHour;
    public float actualSleepRate;

    public bool isEating;
    public bool isToilet;
    public bool isSleep;
    public bool isBusy;
    // Start is called before the first frame update
    void Start()
    {
        //We multiply the vaue by 3 because we intend to update the value every 3 seconds (to save computin power)
        actualFoodRate = foodRatePerHour / 3600 * 3;
        actualToiletRate = toiletRatePerHour / 3600 * 3;
        actualSleepRate = sleepRatePerHour / 3600 * 3;
        StartCoroutine(LowerStats());
    }
    public IEnumerator LowerStats()
    {
        //update every 3 seconds to save computing power
        yield return new WaitForSeconds(3);
        food = food - actualFoodRate;
        toilet = toilet - actualToiletRate;
        sleep = sleep - actualSleepRate;
        StartCoroutine(LowerStats());
        
    }
    private void DoFood()
    {

    }
    private void DoToilet()
    {

    }
    private void DoSleep()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!isBusy && food <30)
        {
            DoFood();
        }
        if (!isBusy && toilet < 30)
        {
            DoToilet();
        }
        if (!isBusy && sleep < 10)
        {
            DoSleep();
        }
    }
}
