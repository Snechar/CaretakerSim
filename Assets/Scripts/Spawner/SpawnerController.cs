using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType
{
    Pills,

}

public class SpawnerController : MonoBehaviour
{
    public SpawnerScript[] Spawners;
    public RoomManager roomController;
    public SpawnType type = SpawnType.Pills;
    public bool DebugSpawner;

    void Start()
    {
        Spawners = this.GetComponentsInChildren<SpawnerScript>();
        foreach (var item in Spawners)
        {
            item.Controller = this;
        }
    }

    public void SpawnRandomPills(int number)
    {
        if (DebugSpawner)
        {
            Spawners[Random.Range(0, Spawners.Length)].EnablePills();
        }
 
    }

    private void Update()
    {
        if (DebugSpawner)
        {
            switch (type)
            {
                case SpawnType.Pills:

                    break;

            }
        }
    }
}
