using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public GameObject VictoryUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("GameOver", 0.1f);
        }
    }
    void GameOver()
    {
        VictoryUI.SetActive(true);
        Time.timeScale = 0f;
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }

}
