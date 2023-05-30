using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMoveState : AIBaseState
{

    public override void EnterState(AIStateManager Ai)
    {
        Ai.animator.Play("Walk");
    }

    public override void UpdateState(AIStateManager Ai)
    {

    }
}
