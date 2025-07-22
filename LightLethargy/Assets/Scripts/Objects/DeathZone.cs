using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerController>(out var player))
        {
            DeathHandler.Instance.KillPlayer();
        }
    }
} 