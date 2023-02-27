using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public Animator crossFade;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            crossFade.SetTrigger("Start");
            StartCoroutine(TriggerDelay());
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private IEnumerator TriggerDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DeathScreen");
    }
}
