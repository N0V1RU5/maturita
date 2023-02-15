using UnityEngine;

public class LightFlickerEffect : MonoBehaviour
{
    public float minIntensity = 0.25f;
    public float maxIntensity = 0.5f;
    public float flickerSpeed = 0.05f; // how fast the light flickers
    public float flickerDuration = 0.1f; // how long the flicker lasts

    new Light light;
    float currentFlickerDuration;

    void Start()
    {
        light = GetComponent<Light>();
        currentFlickerDuration = flickerDuration;
    }

    void Update()
    {
        currentFlickerDuration -= Time.deltaTime;

        if (currentFlickerDuration <= 0)
        {
            float randomValue = Random.Range(minIntensity, maxIntensity);
            light.intensity = randomValue;

            currentFlickerDuration = flickerDuration + Random.Range(-flickerSpeed, flickerSpeed); // add randomness to flicker duration
        }
    }
}
