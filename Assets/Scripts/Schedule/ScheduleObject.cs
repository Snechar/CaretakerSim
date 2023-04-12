using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScheduleObject  
{
    [Range(0,24)]
    public double startTime;
    [Range(0, 24)]
    public double endTime;
    public Interactable interactable;
    public bool hasEnded = false;
    public bool hasStarted = false;
    public bool nextTask = false;
    public bool playedToday=false;
}
