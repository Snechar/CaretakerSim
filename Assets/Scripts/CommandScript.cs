using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CommandScript : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    private void Start()
    {
        if (agent != null)
        {
            agent.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (agent == null)
                return;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "NPC" && hit.transform.gameObject != agent)
                {
                    agent.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    agent = hit.transform.gameObject.GetComponent<NavMeshAgent>();
                    agent.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
        }
            if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(cam.transform.position, cam.transform.forward * 500, Color.green, 3f);
            
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

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
