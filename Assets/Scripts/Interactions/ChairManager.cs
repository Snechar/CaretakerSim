using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : ManagerBase
{
    public NPCStats Npc;
    public void SitNpc(NPCStats npc)
    {
        Debug.Log("Just went to the chair");
        Npc = npc;
        npc.isBusy = true;
    }
    public void RemoveNPC(NPCStats npc)
    {
        this.Npc=null;
        npc.isBusy=false;
    }

    public override void OnUse(NPCStats npc)
    {
        throw new System.NotImplementedException();
    }
}
