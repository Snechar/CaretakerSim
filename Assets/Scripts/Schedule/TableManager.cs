using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public int numberOfChairs;
    public List<ChairManager> chairManagers = new List<ChairManager>();
    // Start is called before the first frame update
    void Start()
    {
        numberOfChairs = chairManagers.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfChairs != chairManagers.Count)
        {
            numberOfChairs = chairManagers.Count;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<ChairManager>() != null)
        {
            return;
        }
        else
        {
            chairManagers.Add(other.gameObject.GetComponent<ChairManager>());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<ChairManager>() != null || chairManagers.Contains(other.gameObject.GetComponent<ChairManager>()))
        {
            return;
        }
        else
        {
            chairManagers.Add(other.gameObject.GetComponent<ChairManager>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ChairManager>() != null)
        {
            return;
        }
        else if(chairManagers.Contains(other.gameObject.GetComponent<ChairManager>()))
        {
            chairManagers.Remove(other.gameObject.GetComponent<ChairManager>());
        }
    }
}
