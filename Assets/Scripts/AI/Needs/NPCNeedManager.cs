using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCNeedManager : MonoBehaviour
{

    public BaseNeed currentNeed;
    public PillsNeed pillsNeed = new PillsNeed();
    public HipBagNeed hipsNeed = new HipBagNeed();
    public TessaNeed tessaNeed = new TessaNeed();


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
        allNeeds.Remove(allNeeds.Where(x => x.GetType() == need.GetType()).First());
        //switch (need)
        //{
        //    case PillsNeed:
        //        allNeeds.Remove(pillsNeed);
        //        break;
        //    case HipBagNeed:
        //        allNeeds.Remove(hipsNeed);
        //        break;
        //    case TessaNeed:
        //        allNeeds.Remove(tessaNeed);
        //        break;
        //    default:
        //        break;
        //}
        if (need.GetType() == typeof(HipBagNeed))
        {
            this.GetComponentInChildren<Animator>().SetFloat("BlendWalk", 0.5f);
        }
        if (EventBus.Instance != null)
        {
            EventBus.Instance.NeedFixed.Invoke();
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
