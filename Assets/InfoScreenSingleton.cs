using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoScreenSingleton : MonoBehaviour
{
    public static InfoScreenSingleton Instance;
    public Image Image;
    public TextMeshProUGUI TechName;
    public TextMeshProUGUI description;
    public GameObject activator;
    public bool isActive = false;
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
    private void Start()
    {
         activator.SetActive(false);
    }
    public void Activate(TechnologyDataScriptableObject obj)
    {
        if (obj == null)
        {
            Debug.Log("");
            return;

        }
        Image.sprite = obj.Image;
        TechName.text = obj.TechName;
        description.text = obj.TechDescription;
        StartCoroutine(DelayClick());
        activator.SetActive(true);
    }
    public void Deactivate()
    {
        activator.SetActive(false);
        isActive = false;
    }
    public IEnumerator DelayClick()
    {
        yield return new WaitForSeconds(0.2f);
        isActive = true;
    }
    private void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log("Dectivated");
                Deactivate();
            }
        }
    }
}
