
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class IaControl : MonoBehaviour
{
    public StatKartSO stats;

    NavMeshAgent iaplayer;
    public Vector3 finish;
   // public ListBuffe<Transform> wayPoints = new List<Transform>();
    
   


    void Awake()
    {

        iaplayer = GetComponent<NavMeshAgent>();
        
        
    }
    void Start()
    {
        StartCoroutine(Boost());
        
        
    }

    void Update()
    {
        iaplayer.SetDestination(finish);
        

    }
    public IEnumerator Boost()
    {
        float baseSpeed = stats.maxSpeed;
        while (true)
        {
            iaplayer.speed = baseSpeed * 3f;
            yield return new WaitForSeconds(2f);

            iaplayer.speed = baseSpeed;
            float delayMin = 1f, delayMax = 3f;
            float interval = Random.Range(delayMin, delayMax);
            yield return new WaitForSeconds(interval);
        }
    }
    
   
}
#region GuardCode

//public class Guard : MonoBehaviour
//{
//    public enum GuardState
//    {
//        Patrol,
//        Chase,
//    }
//    private GuardState state;

//    [SerializeField] List<Transform> list = new List<Transform>();
//    int choices;
//    NavMeshAgent agent;

//    [Header("Vision")]
//    [SerializeField] float maxDistance;
//    [SerializeField] float maxAngle;
//    [SerializeField] Transform player;





//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();
//        state = GuardState.Patrol;


//        ChoiceTheDestination();


//    }

//    void ChoiceTheDestination()
//    {
//        choices = Random.Range(0, list.Count);
//        Transform wayPointCourant = list[choices]; //prend le random pour en faire un point courant

//        agent.SetDestination(list[choices].position);
//    }




//    void Update()
//    {



//        switch (state)
//        {
//            case GuardState.Patrol:
//                if (!agent.pathPending && agent.remainingDistance <= 0.5f)
//                {

//                    ChoiceTheDestination();
//                }
//                if (CanWeSeeThePlayer())
//                {
//                    state = GuardState.Chase;

//                }

//                break;
//            case GuardState.Chase:
//                agent.SetDestination(player.position);
//                if (!CanWeSeeThePlayer())
//                {
//                    state = GuardState.Patrol;
//                }
//                break;
//        }


//    }

//    bool CanWeSeeThePlayer()
//    {
//        RaycastHit hit;
//        Vector3 playerDirection = player.position - transform.position;
//        if (Physics.Raycast(transform.position + Vector3.up * 0.3f, playerDirection, out hit, maxDistance)) //out hit = 
//        {

//            if (hit.collider.CompareTag("Player"))
//            {
//                if (Vector3.Angle(transform.forward, playerDirection) <= maxAngle)
//                {
//                    return true;
//                }
//            }
//        }
//        return false;
//    }


//}
#endregion 