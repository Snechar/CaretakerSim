using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIdleState : AIBaseState
{ 
    

    public override void EnterState(AIStateManager Ai)
    {
        Ai.animator.Play("Idle");
    }

    public override void UpdateState(AIStateManager Ai)
    {
        if (!Ai.npc.isBusy && !Ai.npc.hasPath && !Ai.Idled)
        {
            Ai.npc.MoveToLocationSecureNoInteractCall(Ai.npc.room.RandomIdleManager().transform, this);
            Ai.Idled = true;
            StartCoroutine(WaitSeconds(10, Ai));
        }
    }

    public IEnumerator WaitSeconds(int seconds, AIStateManager Ai)
    {
        
        yield return new WaitForSeconds(seconds);
        Ai.Idled = false;
    }
}
