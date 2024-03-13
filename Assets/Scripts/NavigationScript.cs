using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavigationScript : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    public float followDistance = 250f; 

    public GameObject GameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance)
        {
            agent.destination = player.position;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player touched by GameObject");
    //        Invoke("GameOver", 0.1f);
           
    //    }
    //}

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