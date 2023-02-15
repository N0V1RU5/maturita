using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider mouseSens;

    private void Start()
    {
        // Load the saved mouse sensitivity, if it exists
        if (PlayerPrefs.HasKey("mouseSensitivity"))
        {
            mouseSens.value = PlayerPrefs.GetFloat("mouseSensitivity");
        }
        else
        {
            mouseSens.value = 2f;
        }

        mouseSens.onValueChanged.AddListener(UpdateSensitivity);
    }

    private void UpdateSensitivity(float value)
    {
        // Save the new mouse sensitivity
        PlayerPrefs.SetFloat("mouseSensitivity", value);
    }
}
