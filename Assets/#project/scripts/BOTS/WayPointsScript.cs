using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.AI;

public class WayPointsScript : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    NavMeshAgent agent;
    int currentIndex = 0;
   
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        
    }

    void Update()
    {
        //quand onarrive au point passer au suivant
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance +  0.5f)
        {
            currentIndex++;
            
        }
        Course();

    }
    void Course()
    {
        if (waypoints.Count == 0) { return; }
        float distanceToWayPoint = Vector3.Distance(waypoints[currentIndex].position, transform.position);
        agent.SetDestination(waypoints[currentIndex].position);
    }

           
    
}
