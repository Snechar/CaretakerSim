using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Schedule", menuName ="ScriptableObjects/NPC")]
[Serializable]
public class ScheduleObject : ScriptableObject 
{
    [Range(0,24)]
    public int startTime;
    [Range(0, 24)]
    public int endTime;
    public Interactable interactable;
}
