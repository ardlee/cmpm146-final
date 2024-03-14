using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnRadius = 10f;
    public float timerDuration = 5f; // Duration in seconds
    private float timer; // Timer to track elapsed time
    private bool playerPresent = false; // Flag to check if player is present


    void Update()
    {
        // If player is present, start or continue the timer
        if (playerPresent)
        {
            timer += Time.deltaTime;
            // Check if the timer has reached the specified duration
            if (timer >= timerDuration)
            {
                SpawnObject();
                Debug.Log("Action performed!");
                // Reset the timer
                timer = 0f;
            }
        }
    }

    // When player enters the collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = true;

        }
    }

    // When player exits the collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPresent = false;
            // Reset the timer when the player leaves
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        // Generate a random point within a spawnRadius
        Vector3 randomPoint = transform.position + Random.insideUnitSphere * spawnRadius;

        // Spawn the object at the random point
        Instantiate(objectToSpawn, randomPoint, Quaternion.identity);
    }
}
