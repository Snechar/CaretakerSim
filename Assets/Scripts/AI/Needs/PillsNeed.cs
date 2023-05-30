using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsNeed : BaseNeed
{
    private bool SpawnPills = true;
    public override void CreateNeed(NPCNeedManager nPCNeedManager)
    {
        
    }

    public override void OnCall(NPCNeedManager nPCNeedManager)
    {
        nPCNeedManager.GetComponent<NPCStats>().room.StartSpawningPills();
        if (SpawnPills)
        {
            SpawnPills = false;
            nPCNeedManager.StartCoroutine(WaitToSpawnPills(nPCNeedManager));
            Debug.Log("Spawned a pill");
        }
    }

    public IEnumerator WaitToSpawnPills(NPCNeedManager nPCNeedManager)
    {
        nPCNeedManager.GetComponent<NPCStats>().room.spawnerControllers.SpawnRandomPills(0);
        yield return new WaitForSeconds(UnityEngine.Random.Range(60, 180));
        SpawnPills = true;

        
    }
}
