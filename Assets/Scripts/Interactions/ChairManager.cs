using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : ManagerBase
{
    public NPCStats Npc;
    public void SitNpc(NPCStats npc)
    {
        Debug.Log("Just went to the chair");

        npc.currentSchedule.hasEnded = true;
        npc.SerializeSchedules();
    }
    public void RemoveNPC()
    {
        this.Npc=null;
    }
}
