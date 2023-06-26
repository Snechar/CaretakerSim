using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteract : Interactable
{
    [SerializeField]
    public override GameObject interactionObject { get ; set ; }

    public BedManager bman;
    public int Hello;

    private void Start()
    {

    }
    public override void OnUse(NPCStats npc)
    {
        bman.StartSleep(npc);
    }

    public override ManagerBase GetManager(NPCStats npc)
    {
        return bman;
    }

    public override GameObject GetLocation(NPCStats npc)
    {
        return bman.gameObject;
    }
}
