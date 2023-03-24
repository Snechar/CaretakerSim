using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    //get a list of NPCs by the script NPCStats (each npc must have one of these scripts)
    public NPCStats[] NPCs = FindObjectsOfType<NPCStats>();


    // Update is called once per frame
    void Update()
    {
        
    }
}
