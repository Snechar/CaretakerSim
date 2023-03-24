using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedManager : MonoBehaviour
{
    public NPCStats Npc;
    public float expectedHoursOfSleep;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ForceWakeUp()
    {
        WakeUp(Npc);
    }
    private void WakeUp(NPCStats npc)
    {
       if(npc == null) { return; }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
