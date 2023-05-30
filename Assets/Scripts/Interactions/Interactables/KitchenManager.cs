using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenManager : ManagerBase
{
    public int foodRestore;

    public List<ChairManager> chairs = new List<ChairManager>();


    public void Eat(NPCStats npc)
    {
        npc.food += foodRestore;
        Mathf.Clamp(npc.food, 0, 100);
        

    }

    public override void OnUse(NPCStats npc)
    {
        Eat(npc);
    }
}
