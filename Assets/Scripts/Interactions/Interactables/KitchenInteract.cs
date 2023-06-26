using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenInteract : Interactable
{
    public override GameObject interactionObject { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public KitchenManager kman;
    public GameObject location;

    public override ManagerBase GetManager(NPCStats npc)
    {
        return kman;
    }

    public override void OnUse(NPCStats npc)
    {
        kman.Eat(npc);
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
        return location;
    }
}
