using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 30;
    public int currentHealth;
    public Image healthBar; // Reference to the UI Image for the health bar
    public GameObject GameOverUI;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI(); // Update the health UI when the game starts
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider's GameObject has the tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Reduce player's health
            TakeDamage(10); // Adjust damage value as needed
            Debug.Log(currentHealth);
            UpdateHealthUI(); // Update the health UI when the player takes damage
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if player's health is less than or equal to 0
        if (currentHealth <= 0)
        {
            // Player is defeated, you can implement game over logic here
            Invoke("GameOver", 0.1f);
            Debug.Log("Player defeated!");
        }
    }

    void UpdateHealthUI()
    {
        // Calculate the fill amount for the health bar based on the player's current health
        float fillAmount = (float)currentHealth / maxHealth;
        healthBar.fillAmount = fillAmount;
    }

    void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
