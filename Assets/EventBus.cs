using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class EventBus : MonoBehaviour
{
    public static EventBus Instance;
    public UnityEvent NeedFixed;

    private void Awake()
    {
        Instance = this;
        NeedFixed.AddListener(EventTrigger);
    }
    public void EventTrigger()
    {
       // Debug.Log("triggered event");
    }
}
