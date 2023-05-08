using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light[] lights;

    private void Start()
    {
            lights = FindObjectsOfType<Light>();
        StartCoroutine(CheckForTimeAndUpdateLights());
    }

    private IEnumerator CheckForTimeAndUpdateLights()
    {
        yield return new WaitForSeconds(1);
        if (TimeController.Instance.currentTime.TimeOfDay > TimeSpan.FromHours(20) || TimeController.Instance.currentTime.TimeOfDay < TimeSpan.FromHours(8))
        {
            foreach (var item in lights)
            {
                if (!item.enabled)
                {
                    item.enabled = true;
                }
            }
        }
        else
        {
            foreach (var item in lights)
            {
                if (item.enabled)
                {
                    item.enabled = false;
                }
            }
        }
        StartCoroutine(CheckForTimeAndUpdateLights());
    }
}
