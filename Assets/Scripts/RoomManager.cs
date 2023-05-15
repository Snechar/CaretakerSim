using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public NPCStats Npc;
    public BedManager bedManager;

    public ManagerBase[] idleManagers;

    private void Start()
    {
        idleManagers = this.GetComponentsInChildren<IdleManager>();
    }
    public ManagerBase RandomIdleManager()
    {
       return idleManagers[Random.Range(0, idleManagers.Length)];
    }

    public ToiletManager GetToiletInRoom()
    {
        return this.GetComponentInChildren<ToiletManager>();
    }
}
