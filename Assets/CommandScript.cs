using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward, Color.green, 3f);
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit: "+ hit.transform.name);
                if (agent == null)
                {
                    try
                    {
                        agent = hit.transform.gameObject.GetComponent<NavMeshAgent>();
                    }
                    catch (System.Exception)
                    {

                        return;
                    }
                    return;
                }

                agent.SetDestination(hit.point);;
            }
        }
    }
}
