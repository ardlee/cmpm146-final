using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public string poolName = "ObjectPool"; // Specify the name of the object pool in the PoolManager
    public Transform spawnPoint; // Spawn point for objects
    public float spawnInterval = 2f; // Time interval between spawns

    private float timeSinceLastSpawn = 0f;
    private bool playerInsideTriggerZone = false;

    private void Update()
    {
        if (playerInsideTriggerZone)
        {
            timeSinceLastSpawn += Time.deltaTime;

            if (timeSinceLastSpawn >= spawnInterval)
            {
                // Call the SpawnFromPool method from the PoolManager
                GameObject spawnedObject = PoolManager.Instance.SpawnFromPool();

                if (spawnedObject != null)
                {
                    

                    // Reset the timeSinceLastSpawn
                    timeSinceLastSpawn = 0f;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has entered the trigger zone, increase the spawn rate
            playerInsideTriggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player has exited the trigger zone, reset the spawn rate
            playerInsideTriggerZone = false;
        }
    }
}
