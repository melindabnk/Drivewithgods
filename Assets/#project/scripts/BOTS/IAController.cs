using System.Collections.Generic;
using System.Runtime.Serialization.Configuration;
using UnityEngine;
using UnityEngine.AI;

public class IAController : MonoBehaviour
{
    [Header("composants")]
    [SerializeField] Rigidbody rb;
    [SerializeField] IAProfile so;
    [SerializeField] NavMeshAgent agent;

    [Header("variables")]
    private int currentIndex = 0;
    [SerializeField] List<Transform> waypoints = new List<Transform>();
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        controlOff();
        agent.speed = so.maxSpeed;
        agent.angularSpeed = so.turnSpeed;
        agent.acceleration = so.accel;
        agent.stoppingDistance = so.decel;


    }

    void Update()
    {
        controlOn();
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.5f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Count)
                currentIndex = 0;

        }
        Course();
      

    }
    void Course()
    {
        if (waypoints.Count == 0) { return; }
        float distanceToWayPoint = Vector3.Distance(waypoints[currentIndex].position, transform.position);
        agent.SetDestination(waypoints[currentIndex].position);
    }
    public void controlOn()
    {
        agent.isStopped = false;
    }
    public void controlOff()
    {
        agent.isStopped = true;
    }

}

