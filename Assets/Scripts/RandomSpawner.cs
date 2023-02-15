using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject[] objects;

    private void Start()
    {
        spawn(objects, spawns);
    }
    void Update()
    {
    }

    void spawn(GameObject[] gameObjects, Transform[] locations, bool allowOverlap = false)
    {

        List<GameObject> remainingGameObjects = new List<GameObject>(gameObjects);
        List<Transform> freeLocations = new List<Transform>(locations);

        if (locations.Length < gameObjects.Length)
            Debug.LogWarning(allowOverlap ? "There are more gameObjects than locations. Some objects will overlap." : "There are not enough locations for all the gameObjects. Some won't spawn.");

        while (remainingGameObjects.Count > 0)
        {
            if (freeLocations.Count == 0)
            {
                break;
            }

            int gameObjectIndex = Random.Range(0, remainingGameObjects.Count);
            int locationIndex = Random.Range(0, freeLocations.Count);
            Instantiate(gameObjects[gameObjectIndex], locations[locationIndex].position, locations[locationIndex].rotation);
            remainingGameObjects.RemoveAt(gameObjectIndex);
            freeLocations.RemoveAt(locationIndex);
        }
    }
}
