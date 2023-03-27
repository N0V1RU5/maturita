using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FakeTarget : Target
{
    public Animator crossFade;
    public override void TakeDamage()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(TriggerDelay());
        Cursor.lockState = CursorLockMode.Confined;
    }

    private IEnumerator TriggerDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("DeathScreen");
    }
}