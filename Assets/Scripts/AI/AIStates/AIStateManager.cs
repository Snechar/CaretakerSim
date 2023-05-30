using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
   public NPCStats npc;
   public AIBaseState currentState;
   public AIIdleState idleState;
   public AIMoveState moveState;
   public AINeedsState needsState;
   public AIBusyState busyState;
   public bool Idled;
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        npc = GetComponent<NPCStats>();
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
        animator =GetComponentInChildren<Animator>();
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
        currentState.EnterState(this);
    }
}
