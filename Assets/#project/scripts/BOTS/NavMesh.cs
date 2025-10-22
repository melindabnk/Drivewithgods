
using System.Collections;
using Unity.MLAgents;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;


public class IaControl : MonoBehaviour
{
    public StatKartSO stats;

    NavMeshAgent iaplayer;
    public Vector3 finish;
    float currentSpeed;
    
   


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
            iaplayer.speed = baseSpeed * 2f;
            yield return new WaitForSeconds(2f);

            iaplayer.speed = baseSpeed;
            float delayMin = 2f, delayMax = 5f;
            float interval = Random.Range(delayMin, delayMax);
            yield return new WaitForSeconds(interval);
        }
    }
    
   
}
