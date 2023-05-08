using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public NPCStats Npc;
    public BedManager bedManager;

    public List<ManagerBase> idleManagers = new List<ManagerBase>();


    public ManagerBase RandomIdleManager()
    {
       return idleManagers[Random.Range(0, idleManagers.Count)];
    }

}
