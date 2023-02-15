using UnityEngine;

public class EnemyTeleport : MonoBehaviour
{
    public Transform mainPoint; // main point
    public Transform[] sidePoints; // array of side points
    public Transform additionalPoint; // additional point
    public float teleportTime = 2f; // time between teleporting to next spot
    public float sidePointProbability = 0.1f; // probability to teleport to side point
    public float additionalPointProbability = 0.01f; // probability to teleport to additional point
    public float sidePointDuration = 5f; // duration of staying on side point
    public float additionalPointDuration = 10f; // duration of staying on additional point

    bool onSidePoint = false; // flag indicating if on side point
    bool onAdditionalPoint = false; // flag indicating if on additional point
    float sidePointTimer = 0f; // timer for staying on side point
    float additionalPointTimer = 0f; // timer for staying on additional point
    float teleportTimer = 0f; // timer for teleporting to next spot

    void Update()
    {
        teleportTimer += Time.deltaTime;

        if (teleportTimer >= teleportTime)
        {
            if (onSidePoint) // check if on side point
            {
                sidePointTimer += Time.deltaTime;

                if (sidePointTimer >= sidePointDuration)
                {
                    // move back to main point
                    transform.position = mainPoint.position;
                    onSidePoint = false;
                }
            }
            else if (onAdditionalPoint) // check if on additional point
            {
                additionalPointTimer += Time.deltaTime;

                if (additionalPointTimer >= additionalPointDuration)
                {
                    // move back to main point
                    transform.position = mainPoint.position;
                    onAdditionalPoint = false;
                }
            }
            else
            {
                float randomValue = Random.value; // get random value between 0 and 1

                if (randomValue <= sidePointProbability)
                {
                    // select random side point
                    int randomSidePoint = Random.Range(0, sidePoints.Length);
                    // move to the selected side point
                    transform.position = sidePoints[randomSidePoint].position;
                    onSidePoint = true;
                    sidePointTimer = 0f;
                }
                else if (randomValue <= sidePointProbability + additionalPointProbability)
                {
                    // move to the additional point
                    transform.position = additionalPoint.position;
                    onAdditionalPoint = true;
                    additionalPointTimer = 0f;
                }
                else
                {
                    // move to the main point
                    transform.position = mainPoint.position;
                }
                teleportTimer = 0f;
            }
        }
    }
}
