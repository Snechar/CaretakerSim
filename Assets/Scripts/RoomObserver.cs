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

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {

        }           
    }


}
