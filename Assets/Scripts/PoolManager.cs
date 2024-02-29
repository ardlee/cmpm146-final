using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


// used chatgpt to aid me asked it how to spawn object from a pool using singleton
public class PoolManager : SingletonEx<PoolManager>
{
    public GameObject[] prefabs;
    public int poolSize = 20;

    private List<GameObject> objectPool;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            //randomly picks a prefab
            GameObject randomPrefab = prefabs[Random.Range(0, prefabs.Length)];

            //instantiate
            GameObject obj = Instantiate(randomPrefab);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject SpawnFromPool()
    {
        Vector3 randomPos = new Vector3(Random.Range(-120, -40), Random.Range(1, 2), Random.Range(-120,-72));

        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = randomPos;
                obj.SetActive(true);
                return obj;
            }
        }

        // If all objects are in use dont spawn more, just print to console
        Debug.LogWarning("All objects in use");
        return null;
    }
}
