using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathingCamera : MonoBehaviour
{
    public float speed = 1.0f;
    public float maxDisplacement = 0.05f;

    private Vector3 initialPosition;
    private float time = 0;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime * speed;
        float x = Mathf.PerlinNoise(time, 0) * 2 - 1;
        float y = Mathf.PerlinNoise(0, time) * 2 - 1;
        Vector3 displacement = new Vector3(x, y, 0) * maxDisplacement;
        transform.position = initialPosition + displacement;
    }
}
