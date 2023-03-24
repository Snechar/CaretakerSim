using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{
    public NPCStats Npc;
    public void SitNpc(NPCStats npc)
    {
        Npc = npc;
    }
    public void RemoveNPC()
    {
        this.Npc=null;
    }
}
