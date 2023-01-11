using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    int furthestWaypointIndex = 0;

    public virtual void TakeDamage()
    {
        EnemyAI enemyAI = GetComponent<EnemyAI>();   // Get a reference to the EnemyAI component

        // Find the waypoint that is furthest from the player
        Vector3 playerPosition = GameObject.FindWithTag("Player").transform.position;   // Get the player's position
        float maxDistance = 0.0f;
        furthestWaypointIndex = 0;
        for (int i = 0; i < enemyAI.waypoints.Length; i++)
        {
            float distance = Vector3.Distance(playerPosition, enemyAI.waypoints[i].position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                furthestWaypointIndex = i;
            }
        }

        gameObject.SetActive(false);   // Deactivate the enemy game object

        // Respawn the enemy at the furthest waypoint after a delay
        Invoke("Respawn", 10.0f);
    }

    private void Respawn()
    {
        EnemyAI enemyAI = GetComponent<EnemyAI>();   // Get a reference to the EnemyAI component

        // Set the enemy's position to the furthest waypoint
        transform.position = enemyAI.waypoints[furthestWaypointIndex].position;
        gameObject.SetActive(true);   // Reactivate the enemy game object
    }

}
