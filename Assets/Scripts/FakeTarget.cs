using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeTarget : Target
{
    public int Respawn;

    public override void TakeDamage()
    {
        SceneManager.LoadScene(Respawn);
        Debug.Log("you are dead");
    }
}