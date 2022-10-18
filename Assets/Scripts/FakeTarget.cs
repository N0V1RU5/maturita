using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeTarget : Target
{
    public int Respawn;

    public override void TakeDamage(float amount)
    {
        SceneManager.LoadScene(Respawn);
        Debug.Log("asdf");
    }
}
