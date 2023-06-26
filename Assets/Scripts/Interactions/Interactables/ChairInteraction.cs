using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairInteraction : Interactable
{
    public override GameObject interactionObject { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ManagerBase Manager;

    public override ManagerBase GetManager(NPCStats npc)
    {
        return Manager;
    }

    public override void OnUse(NPCStats npc)
    {
        Debug.Log("Just went to the chair");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override GameObject GetLocation(NPCStats npc)
    {
        throw new System.NotImplementedException();
    }
}
