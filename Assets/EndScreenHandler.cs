using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EndScreenHandler : MonoBehaviour
{
    public List<NPCNeedManager> npcNeedManagers;
    public TextMeshProUGUI text;
    public GameObject EndScreen;
    // Start is called before the first frame update
    void Start()
    {
        npcNeedManagers = FindObjectsOfType<NPCNeedManager>().ToList();
        EventBus.Instance.NeedFixed.AddListener(CheckNeeds);
    }
    public void CheckNeeds()
    {
        int i = 0;
        foreach (var item in npcNeedManagers)
        {
            i += item.allNeeds.Count;
        }
        if (i==0)
        {
            //finish game
            text.text = "Congrats on finishing the game. You have fixed all the needs of the patients with technology." + "\n"+
                " Your total time is :" + ((TimeController.Instance.Day * 24) + TimeController.Instance.currentTime.TimeOfDay.TotalMinutes) / 96 + "Minutes";

            EndScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
