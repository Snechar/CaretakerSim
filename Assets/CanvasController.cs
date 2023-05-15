using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public static CanvasController Instance;
    public GameObject InteractText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void DisableInteractText()
    {
        InteractText.SetActive(false);
    }
    public void EnableInteractText()
    {
        InteractText.SetActive(true);
    }
}
