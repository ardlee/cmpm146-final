using UnityEngine;

public class SafeZoneSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRadius = 750f;
    public LayerMask groundLayer;
    public GameObject goal;

    void Start()
    {
        goal = SpawnObject();
    }

    private GameObject SpawnObject()
    {
        while (true) // Run the loop indefinitely until the object spawns on the ground
        {
            // Generate a random point within a spawnRadius
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;

            // Raycast downwards to find the ground
            RaycastHit hit;
            if (Physics.Raycast(randomPoint, Vector3.down, out hit, Mathf.Infinity, groundLayer))
            {
                // Check if the hit point is within a reasonable height threshold
                if (hit.point.y - transform.position.y <= 3f)
                {
                    // Spawn the object at the hit point
                    return Instantiate(objectToSpawn, hit.point, Quaternion.identity);
                }
            }

            // If the loop reaches here, no suitable ground point was found, so continue the loop
        }
    }
}
