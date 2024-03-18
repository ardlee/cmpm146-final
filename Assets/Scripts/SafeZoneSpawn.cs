using UnityEngine;

public class SafeZoneSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRadius = 10f;
    public LayerMask groundLayer;
    public GameObject goal;

    void Start()
    {
        goal = SpawnObject();
    }

    private GameObject SpawnObject()
    {
        // Generate a random point within a spawnRadius
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;

        // Raycast downwards to find the ground
        RaycastHit hit;
        if (Physics.Raycast(randomPoint, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            // Spawn the object at the hit point
            return Instantiate(objectToSpawn, hit.point, Quaternion.identity);
        }
        return Instantiate(objectToSpawn, new Vector3(1000, 1000, 1000), Quaternion.identity);
    }
}
