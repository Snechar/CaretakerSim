using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipBagNeed : BaseNeed
{
    public override void CreateNeed(NPCNeedManager nPCNeedManager)
    {
        nPCNeedManager.gameObject.GetComponentInChildren<Animator>().SetFloat("BlendWalk", 1f);
    }

    public override void OnCall(NPCNeedManager nPCNeedManager)
    {
        
    }


}
