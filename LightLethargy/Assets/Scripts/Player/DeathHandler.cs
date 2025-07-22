using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    public static DeathHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void KillPlayer()
    {
        Debug.Log("Player has died (no lamp in head for too long)");
    }
} 