using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public NPCNeedManager npcNeedManager;
    public GameObject EndScreenTutorial;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Instance.NeedFixed.AddListener(CheckNeeds);
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckNeeds()
    {
        if (npcNeedManager.allNeeds.Count <=0)
        {
            EndScreenTutorial.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
