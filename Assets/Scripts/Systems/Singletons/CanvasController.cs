using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour
{

    public static CanvasController Instance;
    public GameObject InteractText;
    public GameObject DropText;
    public GameObject ReadText;
    public bool shouldRemove = true;
    public GameObject Menu;

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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Menu.activeSelf)
            {
                Menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void DisableInteractText()
    {
        if (shouldRemove)
        {
            InteractText.SetActive(false);
        }
    
    }
    public void EnableInteractText()
    {
        //InteractText.GetComponent<TextMeshPro>().text = text;
        InteractText.SetActive(true);
    }
    public void DisableDropText()
    {
        DropText.SetActive(false);
    }
    public void EnableDropText()
    {
        DropText.SetActive(true);
    }
    public void DisableReadText()
    {
        ReadText.SetActive(false);
    }
    public void EnableReadText()
    {
        ReadText.SetActive(true);
    }
}
