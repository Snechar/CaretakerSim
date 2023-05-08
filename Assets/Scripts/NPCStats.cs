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
    private float actualSleepRate;

    public bool isEating;
    public bool isToilet;
    public bool isSleep;
    public bool isBusy;
    private bool isPathing = false;

    private float previousHour;
    public ScheduleObject currentSchedule;
    public ScheduleObject currentNeed;
    public NavMeshAgent agent;
    private bool hasPath = false;
    [SerializeField]
    private bool finishedCurrentTask = false;
    [SerializeField]
    private bool isDoingCurrentTask = false;
    [SerializeField]
    private bool finishedCurrentNeed = false;
    [SerializeField]
    private bool isDoingCurrentNeed = false;
    private AIStateManager stateManager;
    public RoomManager room;



    private void StartTask()
    {
        while (isDoingCurrentNeed)
        {
            Debug.Log("Is Waiting");
        }
        currentSchedule = ScheduleManager.Instance.currentSchedule;
        isDoingCurrentTask = true;
        finishedCurrentTask= false;
        stateManager.UpdateState(currentSchedule.stateToEnter);
        StartCoroutine(MoveToLocationSecure(ScheduleManager.Instance.currentSchedule.manager.gameObject.transform, currentSchedule));

    }
    public void StartSpecifiNeed(ScheduleObject schedule)
    {
        if (isBusy)
        {
            return;
        }
        currentNeed = schedule;
        isDoingCurrentTask = true;
        finishedCurrentTask = false;
        stateManager.UpdateState(currentNeed.stateToEnter);
        StartCoroutine(MoveToLocationSecure(currentNeed.manager.gameObject.transform, currentNeed));
    }
    private void EndTask()
    {
        currentSchedule = null;
        isDoingCurrentTask = false;
        finishedCurrentTask = true;
        stateManager.UpdateState(stateManager.idleState);
    }
    public void EndNeed()
    {
        currentNeed = null;
        isDoingCurrentNeed = false;
        finishedCurrentNeed = true;
        stateManager.UpdateState(stateManager.idleState);
    }
    //private IEnumerator CheckForTasks()
    //{
    //    if (ScheduleManager.Instance.currentSchedule == currentSchedule && finishedCurrentTask == true)
    //    {
    //        finishedCurrentTask = true;
    //        isDoingCurrentTask = false;
    //    }
    //    if (ScheduleManager.Instance.currentSchedule.hasStarted && currentSchedule != ScheduleManager.Instance.currentSchedule)
    //    {
    //        currentSchedule = ScheduleManager.Instance.currentSchedule;
    //        finishedCurrentTask = false;
    //        isDoingCurrentTask = false;
    //    }
    //    if (ScheduleManager.Instance.currentSchedule.hasStarted && !isDoingCurrentTask && !finishedCurrentTask)
    //    {
    //        isDoingCurrentTask = true;
    //        StartCoroutine(MoveToLocationSecure());

    //    }
    //    yield return new WaitForSeconds(1);
    //    StartCoroutine(CheckForTasks());
    //}

    private IEnumerator MoveToLocationSecure(Transform location, ScheduleObject obj)
    {
        MoveToLocation(location);
        ScheduleObject rememberScheduleObject = obj;
        hasPath = true;
        while (hasPath)
        {
            yield return new WaitForSeconds(0.2f);
            if (!agent.hasPath && agent.velocity.sqrMagnitude == 0f)
            {
                Interact(rememberScheduleObject);
                hasPath = false;
                break;
            }

        }
    }
    public void MoveToLocationSecureNoInteractCall(Transform location)
    {
        StartCoroutine(MoveToLocationSecureNoInteract(location));
    }
    private IEnumerator MoveToLocationSecureNoInteract(Transform location)
    {
        MoveToLocation(location);
        hasPath = true;
        while (hasPath)
        {
            yield return new WaitForSeconds(0.2f);
            if (!agent.hasPath && agent.velocity.sqrMagnitude == 0f)
            {
                hasPath = false;
                break;
            }

        }
       
    }
    private void MoveToLocation(Transform location)
    {
        agent.SetDestination(location.position);
    }

   
    private void Interact(ScheduleObject obj)
    {

       ManagerBase manager  = obj.manager;
        manager.OnUse(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //We multiply the vaue by 3 because we intend to update the value every 3 seconds (to save computing power)
        actualFoodRate = foodRatePerHour / 3600 * TimeController.Instance.timeMultiplier * 3;
        actualToiletRate = toiletRatePerHour / 3600 * TimeController.Instance.timeMultiplier * 3;
        actualSleepRate = sleepRatePerHour / 3600 * TimeController.Instance.timeMultiplier * 3;
        StartCoroutine(LowerStats());

        ScheduleManager.Instance.scheduleStart.AddListener(StartTask);
        ScheduleManager.Instance.scheduleEnd.AddListener(EndTask);
        stateManager = GetComponent<AIStateManager>();

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
        if (currentNeed.manager != null)
        {
            if (currentNeed.manager.GetType() == typeof(ToiletManager))
            {
                return;
            }

        }
        ScheduleObject scheduleObject = new ScheduleObject
        {
            nextTask = true,
            startTime = TimeController.Instance.currentTime.TimeOfDay.TotalHours,
            endTime = (TimeController.Instance.currentTime.TimeOfDay + TimeSpan.FromMinutes(5)).TotalHours,
            stateToEnter = stateManager.busyState,
            hasStarted = true,
            manager = FindObjectOfType<ToiletManager>()
        };
        StartSpecifiNeed(scheduleObject);

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
