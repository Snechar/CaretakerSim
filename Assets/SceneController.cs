using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
   public void StartScene(int value)
    {
        if (value!=0)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        SceneManager.LoadScene(value);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
