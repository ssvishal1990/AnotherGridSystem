using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public LayerMask groundLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, float.MaxValue, groundLayer))
            {
                //Debug.Log(hit.point + "  " + hit.transform.gameObject.name);
                // agent Move
                agent.SetDestination(hit.point);
                Debug.Log(hit.point + "  " + agent.destination + " ");

            }
            
        }
    }
}
