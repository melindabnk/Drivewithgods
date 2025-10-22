using UnityEngine;
using UnityEngine.AI;
using static IaControl;

public class iaSpawner : MonoBehaviour
{
    public int maxIaPlayer = 1;
    public BoxCollider bc;
    public GameObject gb;
    

    void Awake()

    {
        Vector3 randomPOs = RandomPosBox(bc);
    }

    void Start()
    {
        SpawnIaPlayer();
    }

    void SpawnIaPlayer()
    {
        for (int i = 0; i < maxIaPlayer; i++)
        {

            Instantiate(gb,RandomPosBox(bc),Quaternion.identity);
        }
    }
    Vector3 RandomPosBox(BoxCollider box)
    {
        Vector3 local = new Vector3(
        Random.Range(-box.size.x / 2, box.size.x / 2),
        Random.Range(-box.size.y / 2, box.size.y / 2),
        Random.Range(-box.size.z / 2, box.size.z / 2)
    );
        return box.transform.TransformPoint(box.center + local);
    }
}
