using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealBattery : MonoBehaviour
{
    private GameObject flashlight;

    private void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("flashlight");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            flashlight.GetComponent<FlashlightAdvanced>().batteries -= 1;
            Debug.Log("YOINK");
            Destroy(gameObject);
        }
    }
}
