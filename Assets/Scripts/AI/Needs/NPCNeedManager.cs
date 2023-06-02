using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCNeedManager : MonoBehaviour
{
    [SerializeField]
    public BaseNeed currentNeed;
    public PillsNeed pillsNeed = new PillsNeed();
    public HipBagNeed hipsNeed = new HipBagNeed();
    public TessaNeed tessaNeed = new TessaNeed();

    [SerializeField]
    public List<BaseNeed> allNeeds = new List<BaseNeed>();

    public bool hasPillNeed;
    public bool hasHipBagNeed;
    public bool hasTessaNeed;

    public void Start()
    {
        if (hasPillNeed)
        {
            AddNeed(pillsNeed);
        }
        if (hasHipBagNeed)
        {
            AddNeed(hipsNeed);
        }
        else
        {
            this.GetComponentInChildren<Animator>().SetFloat("BlendWalk", 0);
        }
        if (hasTessaNeed)
        {
            AddNeed(tessaNeed);
        }

    }
    public void RemoveNeed(BaseNeed need)
    {
        Debug.Log("Removed need of " + need.GetType().ToString());
        allNeeds.Remove(need);
        if (need.GetType() == typeof(HipBagNeed))
        {
            this.GetComponentInChildren<Animator>().SetFloat("BlendWalk", 0.5f);
        }
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
