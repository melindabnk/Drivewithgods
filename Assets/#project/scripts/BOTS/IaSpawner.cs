using UnityEngine;


public class iaSpawner : MonoBehaviour
{
    [SerializeField] int maxIaPlayer = 1;
    [SerializeField] BoxCollider bc;
    [SerializeField] GameObject gb;
    

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
    Vector3 RandomPosBox(BoxCollider bc)
    {
        Vector3 local = new Vector3(
        Random.Range(-bc.size.x / 2, bc.size.x / 2),
        Random.Range(-bc.size.y / 2, bc.size.y / 2),
        Random.Range(-bc.size.z / 2, bc.size.z / 2)
    );
        return bc.transform.TransformPoint(bc.center + local);
    }
}
