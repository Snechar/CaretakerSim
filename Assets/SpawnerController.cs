using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public SpawnerScript[] Spawners;
    void Start()
    {
        Spawners = this.GetComponentsInChildren<SpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
