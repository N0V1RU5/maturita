using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public virtual void TakeDamage()
    {
        Destroy(gameObject);
    }
}
