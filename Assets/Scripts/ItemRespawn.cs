using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform[] spawnPoints;

    private void Start()
    {
        InvokeRepeating("SpawnBattery", 5f, 5f);
    }

    private void SpawnBattery()
    {
        if (GameObject.FindGameObjectWithTag("Battery"))
        {
            return;
        }

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(itemPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
