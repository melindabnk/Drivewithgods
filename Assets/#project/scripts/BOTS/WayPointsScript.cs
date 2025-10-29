using System.Collections.Generic;
using System.Runtime.InteropServices;
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

        //trouver groupe en allant chercher l'empty par son tag puis en mettant les enfants dans un tranfsorm points
        GameObject group = GameObject.FindWithTag("waypointgroup");
        waypoints.Clear();
        
        Transform[] points = group.GetComponentsInChildren<Transform>();
        
        if (waypoints.Count > 0)
        {
            for (int i = 0; i < points.Length; i++)
            {
                waypoints.Add(points[i]);
            }
        }
        currentIndex = 0;
        agent.SetDestination(waypoints[currentIndex].position);


        
    }

    void Update()
    {
        //quand onarrive au point passer au suivant
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance +  0.5f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Count) { return; }
            //agent.SetDestination(waypoints[currentIndex].position);
        }

    }
    
    
}
