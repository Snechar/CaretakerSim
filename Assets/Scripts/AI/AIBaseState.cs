using UnityEngine;

public abstract class AIBaseState
{
    abstract public void EnterState(AIStateManager Ai);

    abstract public void UpdateState(AIStateManager Ai);

}
