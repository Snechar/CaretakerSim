using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsObject : BaseObject
{

    public override void OnUse(SpawnerScript controller)
    {
        controller.DisablePills();
        


    }
}
