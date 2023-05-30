using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletManager : ManagerBase
{

    public override void OnUse(NPCStats npc)
    {
        npc.isToilet = true;
        StartCoroutine(WairForFinish(npc));


    }
    private void FinishToilet(NPCStats npc)
    {
        npc.isToilet = false;
        npc.toilet = 100;
        npc.EndNeed();
        
    }

    private IEnumerator WairForFinish(NPCStats npc)
    {
        yield return new WaitForSeconds(3);
        FinishToilet(npc);
        npc.isToilet=false;
    }
}
