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
    public bool idleStarted;
    private bool isPathing = false;

    private float previousHour;
    public ScheduleObject currentSchedule;
    public ScheduleObject currentNeed;
    public NavMeshAgent agent;
    public bool hasPath = false;
    [SerializeField]
    private bool finishedCurrentTask = false;
    [SerializeField]
    private bool isDoingCurrentTask = false;
    [SerializeField]
    private bool finishedCurrentNeed = false;
    [SerializeField]
    private bool isDoingCurrentNeed = false;
    public AIStateManager stateManager;
    public RoomManager room;
    public bool needsTessa;
    public bool tutorialNpc;




    private void StartTask()
    {
        while (isDoingCurrentNeed)
        {
            Debug.Log("Is Waiting");
        }

        currentSchedule = ScheduleManager.Instance.currentSchedule;
        if (currentSchedule.canBeSkippedByTessa)
        {
            return;
        }
        isDoingCurrentTask = true;
        finishedCurrentTask= false;
        StartCoroutine(MoveToLocationSecure(ScheduleManager.Instance.currentSchedule.manager.gameObject.transform, currentSchedule,currentSchedule.stateToEnter ));

    }
    public void StartSpecifiNeed(ScheduleObject schedule)
    {
        if (needsTessa)
        {
            if (schedule.canBeSkippedByTessa)
            {
                return;
            }
        }
        if (isBusy)
        {
            return;
        }
        currentNeed = schedule;
        isDoingCurrentTask = true;
        finishedCurrentTask = false;
        StartCoroutine(MoveToLocationSecure(currentNeed.manager.gameObject.transform, currentNeed, currentNeed.stateToEnter));
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

    private IEnumerator MoveToLocationSecure(Transform location, ScheduleObject obj, AIBaseState stateToEnter)
    {
        MoveToLocation(location);
        ScheduleObject rememberScheduleObject = obj;
        hasPath = true;
        stateManager.UpdateState(stateManager.moveState);
        while (hasPath)
        {
            yield return new WaitForSeconds(0.2f);
            if (!agent.hasPath && agent.velocity.sqrMagnitude == 0f  && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
            {
                stateManager.UpdateState(stateManager.moveState);
                stateManager.UpdateState(stateToEnter);
                Interact(rememberScheduleObject);
                hasPath = false;
                break;
            }

        }
    }
    public void MoveToLocationSecureNoInteractCall(Transform location, AIBaseState stateToEnter)
    {
        StartCoroutine(MoveToLocationSecureNoInteract(location, stateToEnter));
    }
    private IEnumerator MoveToLocationSecureNoInteract(Transform location , AIBaseState stateToEnter)
    {
        MoveToLocation(location);
        hasPath = true;
        while (hasPath)
        {
            stateManager.UpdateState(stateManager.moveState);
            yield return new WaitForSeconds(0.2f);
            if (!agent.hasPath && agent.velocity.sqrMagnitude == 0f && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance == 0)
            {
                stateManager.UpdateState(stateManager.idleState);
                hasPath = false;
                break;
            }

        }


    }
    private void MoveToLocation(Transform location)
    {
        agent.SetDestination(location.position);
        stateManager.UpdateState(stateManager.moveState);
    }

   
    private void Interact(ScheduleObject obj)
    {

       ManagerBase manager  = obj.manager;
        manager.OnUse(this);
    }

    // Start is called before the first frame update
    void Start()
    {



        if (!tutorialNpc)
        {
            //We multiply the vaue by 3 because we intend to update the value every 3 seconds (to save computing power)
            actualFoodRate = foodRatePerHour / 3600 * TimeController.Instance.timeMultiplier * 3;
            actualToiletRate = toiletRatePerHour / 3600 * TimeController.Instance.timeMultiplier * 3;
            actualSleepRate = sleepRatePerHour / 3600 * TimeController.Instance.timeMultiplier * 3;
            StartCoroutine(LowerStats());
            ScheduleManager.Instance.scheduleStart.AddListener(StartTask);
            ScheduleManager.Instance.scheduleEnd.AddListener(EndTask);
        }

        stateManager = GetComponent<AIStateManager>();

    }
    public void OnInvertSchedule()
    {
        ScheduleManager.Instance.scheduleStart.RemoveListener(StartTask);
        ScheduleManager.Instance.scheduleEnd.RemoveListener(EndTask);
        ScheduleManager.Instance.invertedscheduleStart.AddListener(StartTask);
        ScheduleManager.Instance.invertedscheduleEnd.AddListener(EndTask);
    }
    public void ReverseInvertSchedule()
    {
        ScheduleManager.Instance.scheduleStart.AddListener(StartTask);
        ScheduleManager.Instance.scheduleEnd.AddListener(EndTask);
        ScheduleManager.Instance.invertedscheduleStart.RemoveListener(StartTask);
        ScheduleManager.Instance.invertedscheduleEnd.RemoveListener(EndTask);
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
            manager = room.GetToiletInRoom()
        };
        StartSpecifiNeed(scheduleObject);

    }
    private void DoSleep()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (tutorialNpc)
        {
            return;
        }
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
