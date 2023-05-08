using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScheduleManager : MonoBehaviour
{
    public static ScheduleManager Instance;
    public List<ScheduleObject> generalSchedule;
    public ScheduleObject currentSchedule;
    public UnityEvent scheduleStart;
    public UnityEvent scheduleEnd;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(CheckSchedule());
        SerializeSchedules();
    }
    public ScheduleObject GetCurrentSchedule()
    {
        return currentSchedule;
    }

    private IEnumerator CheckSchedule()
    {
        yield return new WaitForSeconds(0.2f);
        if ((TimeSpan.FromHours(currentSchedule.endTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && currentSchedule.hasStarted == true)
        {
            currentSchedule.hasEnded = true;
            currentSchedule.playedToday = true;
            SerializeSchedules();
            if (currentSchedule.lastTask)
            {
                ResetSchedule();
            }
            scheduleEnd.Invoke();
        }
        if ((TimeSpan.FromHours(currentSchedule.startTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && !currentSchedule.hasEnded && !currentSchedule.hasStarted)
        {
            currentSchedule.hasStarted = true;
            scheduleStart.Invoke();

        }
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(CheckSchedule());
    }
    public void SerializeSchedules()
    {

        generalSchedule.Sort((p1, p2) => p1.startTime.CompareTo(p2.startTime));
        generalSchedule[generalSchedule.Count-1].lastTask = true;
        for (int i = 0; i < generalSchedule.Count - 1; i++)
        {
            if (currentSchedule.manager == null)
            {
                currentSchedule = generalSchedule[i];
                currentSchedule.nextTask = true;
                break;
            }
            if (generalSchedule[i].hasEnded && !generalSchedule[i+1].hasEnded && !generalSchedule[i+1].hasStarted)
            {
                generalSchedule[i].playedToday = true;
                generalSchedule[i + 1].nextTask = true;
                currentSchedule = generalSchedule[i + 1];
                break;
            }
           
        }


    }

    public void ResetSchedule()
    {
        foreach (var item in generalSchedule)
        {
            item.hasStarted = false;
            item.hasEnded = false;
            item.nextTask = false;
            item.playedToday = false;
        }
        SerializeSchedules();
    }
    //Unused Agent piece of code, might be needed later
    //private IEnumerator CheckSchedule()
    //{

    //    yield return new WaitForSeconds(0.2f);
    //    if ((TimeSpan.FromHours(currentSchedule.endTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && currentSchedule.hasStarted == true)
    //    {
    //        currentSchedule.hasEnded = true;
    //        SerializeSchedules();
    //    }
    //    if ((TimeSpan.FromHours(currentSchedule.startTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && !currentSchedule.hasEnded && !currentSchedule.hasStarted)
    //    {
    //        currentSchedule.hasStarted = true;

    //        agent.SetDestination(currentSchedule.interactable.gameObject.transform.position);
    //        hasPath = true;
    //        while (hasPath)
    //        {
    //            yield return new WaitForSeconds(1);
    //            if (!agent.hasPath && agent.velocity.sqrMagnitude == 0f && currentSchedule.hasStarted)
    //            {
    //                Interact(currentSchedule);
    //                SerializeSchedules();
    //                hasPath = false;
    //                break;
    //            }
    //            if ((TimeSpan.FromHours(currentSchedule.endTime) - TimeController.Instance.currentTime.TimeOfDay).TotalSeconds < 0 && currentSchedule.hasStarted == true)
    //            {
    //                currentSchedule.hasEnded = true;
    //                SerializeSchedules();
    //                break;
    //            }

    //        }


    //    }
    //    StartCoroutine(CheckSchedule());

    //}

}
