using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseNeed
{

    abstract public void CreateNeed(NPCNeedManager nPCNeedManager);

    abstract public void OnCall(NPCNeedManager nPCNeedManager);


}
