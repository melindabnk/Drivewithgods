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
    bool canMove = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Start()
    {
        agent.speed = so.maxSpeed;
        agent.angularSpeed = so.turnSpeed;
        agent.acceleration = so.accel;
        agent.stoppingDistance = so.decel;


    }

    void Update()
    {
        

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.5f)
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
    public void controlOn()
    {
        canMove = true;
    }
    public void controlOff()
    {
        canMove = false;
    }

}

