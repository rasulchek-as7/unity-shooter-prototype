using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;

    public void DestroyTarget()
    {
        gameManager.TargetDestroyed();
        Destroy(gameObject);
    }
}