using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessaNeed : BaseNeed
{
    public override void CreateNeed(NPCNeedManager nPCNeedManager)
    {
        nPCNeedManager.gameObject.GetComponent<NPCStats>().needsTessa = true;
    }

    public override void OnCall(NPCNeedManager nPCNeedManager)
    {

    }
}
