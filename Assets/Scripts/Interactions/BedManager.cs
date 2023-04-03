using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BedManager : ManagerBase
{
    public NPCStats Npc;
    public float expectedHoursOfSleep;
    private System.DateTime snapshotTime;
    private bool isAsleep;
    public GameObject anchorPoint;

    // Start is called before the first frame update
    void Start()
    {
        Npc = this.GetComponentInParent<Transform>().gameObject.GetComponentInParent<RoomManager>().Npc;
    }
    public void StartSleep()
    {
        snapshotTime = TimeController.Instance.currentTime;
        Npc.isSleep = true;
        StartCoroutine(CountSleep());

    }
    IEnumerator CountSleep() {
        if (TimeController.Instance.currentTime >= (snapshotTime + TimeSpan.FromHours(expectedHoursOfSleep)))
        {
            WakeUp(Npc);
        }
        else
        {
            yield return new WaitForSeconds(3);
            StartCoroutine(CountSleep());
        }
    }

    public void ForceWakeUp()
    {
        if (Npc == null) { return; }
        var sleptTime = TimeController.Instance.CalculateTimeDiff(snapshotTime.TimeOfDay, TimeController.Instance.currentTime.TimeOfDay);
        Npc.isSleep = false;
        var percentage = sleptTime.TotalHours * 100 / expectedHoursOfSleep;
        Npc.sleep += (float)percentage;
        Mathf.Clamp(Npc.sleep, 0, 100);
    }
    private void WakeUp(NPCStats npc)
    {
       if(npc == null) { return; }

       Npc.isSleep = false;
        Npc.sleep = 100;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
