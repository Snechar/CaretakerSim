using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : ManagerBase
{

    public List<ChairManager> chairs = new List<ChairManager>();


    public void Eat(NPCStats npc)
    {
        npc.food += 30;
        Mathf.Clamp(npc.food, 0, 100);
        npc.currentSchedule.hasEnded = true;
        npc.SerializeSchedules();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
