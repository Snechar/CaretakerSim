using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    AIBaseState currentState;
    AIIdleState idleState = new AIIdleState();
    AIMoveState moveState = new AIMoveState();
    AINeedsState needsState = new AINeedsState();
    AIBusyState busyState= new AIBusyState();

    public Vector3 locationToGo;
    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
