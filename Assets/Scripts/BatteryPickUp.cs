using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatteryPickUp : MonoBehaviour
{
    private float raycastLength = 5f;

    private GameObject flashlight;

    //public AudioSource pickUpSound;

    void Start()
    {
        flashlight = GameObject.FindGameObjectWithTag("flashlight");
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            BatteryPickup();
            CardPickup();
            ExitCheck();
            ExitTutCheck();
        }
    }

    void BatteryPickup()
    {
        if (Input.GetButtonDown("interact"))
        {
            Vector3 pos = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit hit, raycastLength))
            {
                if (hit.collider.CompareTag("Battery"))
                {
                    //pickUpSound.Play()
                    flashlight.GetComponent<FlashlightAdvanced>().batteries += 1;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    void CardPickup()
    {
        if (Input.GetButtonDown("interact"))
        {
            Vector3 pos = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
            Ray ray = Camera.main.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out RaycastHit hit, raycastLength))
            {
                if (hit.collider.CompareTag("Keycard"))
                {
                    //pickUpSound.Play()
                    flashlight.GetComponent<FlashlightAdvanced>().keycards += 1;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    void ExitCheck()
    {
        if (Input.GetButtonDown("interact"))
        {
            Vector3 pos = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
            Ray ray = Camera.main.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out RaycastHit hit, raycastLength))
            {
                if (hit.collider.CompareTag("Exit") && flashlight.GetComponent<FlashlightAdvanced>().keycards >= 6)
                {
                    SceneManager.LoadScene("WinScreen");
                }
            }
        }
    }

    void ExitTutCheck()
    {
        if (Input.GetButtonDown("interact"))
        {
            Vector3 pos = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0.0f);
            Ray ray = Camera.main.ScreenPointToRay(pos);

            if (Physics.Raycast(ray, out RaycastHit hit, raycastLength))
            {
                if (hit.collider.CompareTag("ExitTut") && flashlight.GetComponent<FlashlightAdvanced>().keycards >= 6)
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
        }
    }
}