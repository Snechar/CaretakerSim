using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
   public AIBaseState currentState;
   public AIIdleState idleState;
   public AIMoveState moveState;
   public AINeedsState needsState;
   public AIBusyState busyState;

    // Start is called before the first frame update
    void Start()
    {


        try
        {
          idleState = FindObjectOfType<AIIdleState>();
          moveState = FindObjectOfType<AIMoveState>();
          needsState = FindObjectOfType<AINeedsState>();
          busyState = FindObjectOfType<AIBusyState>();
        }
        catch (System.Exception)
        {

            throw;
        }

        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void UpdateState(AIBaseState AI)
    {
        currentState= AI;
    }
}
