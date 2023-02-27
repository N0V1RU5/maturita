 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator crossFade;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void PlayGame()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(PlayGameDelay());
    }

    private IEnumerator PlayGameDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Game");
    }

    public void PlayTutorial()
    {
        crossFade.SetTrigger("Start");
        StartCoroutine(PlayTutorialDelay());
    }

    private IEnumerator PlayTutorialDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
