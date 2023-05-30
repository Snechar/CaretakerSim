using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNeedManager : MonoBehaviour
{
    [SerializeField]
    public BaseNeed currentNeed;
    public PillsNeed pillsNeed = new PillsNeed();

    [SerializeField]
    public List<BaseNeed> allNeeds = new List<BaseNeed>();


    public void Start()
    {
        AddNeed(pillsNeed);
    }
    public void RemoveNeed(BaseNeed need)
    {
        Debug.Log("Removed need of " + need.GetType().ToString());
        allNeeds.Remove(need);
    }
    public void AddNeed(BaseNeed needToChange)
    {
        currentNeed = needToChange;
        allNeeds.Add(needToChange);
        currentNeed.CreateNeed(this);
    }
    private void Update()
    {
        if (allNeeds.Count >0)
        {
            foreach (var item in allNeeds)
            {
                item.OnCall(this);
            }
        }

    }
}
