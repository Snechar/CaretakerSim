using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObserver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.transform.tag == "Player")
        {
            Debug.Log("Player Entered");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Player Left");
        }           
    }


}
