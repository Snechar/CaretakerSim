using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
    private bool isPathing = false;

    public List<ScheduleObject> scheduleObjects = new List<ScheduleObject>();
    private float previousHour;
    public ScheduleObject currentSchedule;
    public NavMeshAgent agent;
    private bool hasPath = false;

    private IEnumerator CheckSchedule()
    {
        Debug.Log("RanCoroutine");
        yield return new WaitForSeconds(0.2f);
        if ((TimeSpan.FromHours(currentSchedule.endTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && currentSchedule.hasStarted == true)
        {
            currentSchedule.hasEnded = true;
            SerializeSchedules();
        }
        if ((TimeSpan.FromHours(currentSchedule.startTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && !currentSchedule.hasEnded && !currentSchedule.hasStarted)
        {
           currentSchedule.hasStarted = true;

            agent.SetDestination(currentSchedule.interactable.gameObject.transform.position);
            hasPath = true;
            while (hasPath)
            {
                yield return new WaitForSeconds(1);
                if (!agent.hasPath && agent.velocity.sqrMagnitude == 0f && currentSchedule.hasStarted)
                {
                    Interact(currentSchedule);
                    SerializeSchedules();
                    hasPath = false;
                    break;
                }
                if ((TimeSpan.FromHours(currentSchedule.endTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && currentSchedule.hasStarted == true)
                {
                    currentSchedule.hasEnded = true;
                    SerializeSchedules();
                    break;
                }

            }
       

        }
        StartCoroutine(CheckSchedule());

    }
    private void Interact(ScheduleObject obj)
    {

       ManagerBase manager  = obj.interactable.GetManager(this);
        if (manager is BedManager)
        {
            BedManager bedManager = (BedManager)manager;
            bedManager.StartSleep(this);
        }
        if (manager is KitchenManager)
        {
            KitchenManager kitchenManager = (KitchenManager)manager;
            kitchenManager.Eat(this);
        }
        if (manager is ChairManager)
        {
            ChairManager kitchenManager = (ChairManager)manager;
            kitchenManager.SitNpc(this);
        }



    }
    static int SortByScore(ScheduleObject p1, ScheduleObject p2)
    {
        return p1.startTime.CompareTo(p2.startTime);
    }
    public void SerializeSchedules()
    {

        scheduleObjects.Sort((p1,p2)=>p1.startTime.CompareTo(p2.startTime));
        for (int i = 0; i < scheduleObjects.Count-1; i++)
        {
            if (currentSchedule.hasStarted && currentSchedule.hasEnded && !scheduleObjects[i].playedToday)
            {
                scheduleObjects[i+1].nextTask = true;
                currentSchedule = scheduleObjects[i + 1];
                scheduleObjects[i].playedToday = true;
                break;
            }
            if (currentSchedule.interactable == null)
            {
                currentSchedule = scheduleObjects[i];
                currentSchedule.nextTask = true;
                break;
            }
        }
       
   
    }
    // Start is called before the first frame update
    void Start()
    {
        //We multiply the vaue by 3 because we intend to update the value every 3 seconds (to save computin power)
        actualFoodRate = foodRatePerHour / 3600 * 3;
        actualToiletRate = toiletRatePerHour / 3600 * 3;
        actualSleepRate = sleepRatePerHour / 3600 * 3;
        StartCoroutine(LowerStats());
        StartCoroutine(CheckSchedule());
        SerializeSchedules();
    
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
