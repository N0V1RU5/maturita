using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickStick : MonoBehaviour
{
    public TextMeshProUGUI pickUpText;

    private void Start()
    {
        pickUpText.enabled = false;
    }

    private void Update()
    {
        bool isTouching = false;
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f, transform.rotation);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Battery") || collider.CompareTag("Keycard"))
            {
                isTouching = true;
                break;
            }
        }
        pickUpText.enabled = isTouching;
    }
}
