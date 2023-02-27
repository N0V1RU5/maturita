using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Animator crossFade;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartGame()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(RestartGameDelay());
    }

    private IEnumerator RestartGameDelay()
    {

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(MainMenuDelay());
    }
    private IEnumerator MainMenuDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
