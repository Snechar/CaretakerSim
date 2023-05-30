using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public static RoomController Instance;

    public RoomManager[] roomManagers;
    public NPCStats[] npcStats;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        try
        {
            roomManagers = FindObjectsOfType<RoomManager>();
            npcStats = FindObjectsOfType<NPCStats>();
        }
        catch (System.Exception)
        {

            Debug.Log("Could not find rooms or npcs.");
        }

        AssignNPCAtStart();
    }

    public void AssignNPC(NPCStats npc)
    {
        foreach (var item2 in roomManagers)
        {
            if (item2.Npc == null)
            {
                item2.Npc = npc;
                npc.room = item2;
                return;
            }
        }
    }

    private void AssignNPCAtStart()
    {
        foreach (var item in npcStats)
        {
            if (item.room == null)
            {
                foreach (var item2 in roomManagers)
                {
                    if (item2.Npc == null)
                    {
                        item2.Npc = item;
                        item.room = item2;
                        return;
                    }
                }
            }
        }
    }


}
