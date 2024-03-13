using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caught : MonoBehaviour
{
    public GameObject GameOverUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player touched by GameObject");
            Invoke("GameOver", 0.1f);

        }
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
