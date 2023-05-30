using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleManager : ManagerBase
{
    public override void OnUse(NPCStats npc)
    {
        npc.stateManager.UpdateState(npc.stateManager.idleState);
    }
}
