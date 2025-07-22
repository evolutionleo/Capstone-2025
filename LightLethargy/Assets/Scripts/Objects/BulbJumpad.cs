using System;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class BulbJumpad : MonoBehaviour
    {
        public BulbPlace BulbPlace;
        public float JumpForce = 20f;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!BulbPlace.HasBulb) return;
            if (other.TryGetComponent<PlayerController>(out var player))
            {
                var rb = player.GetComponent<Rigidbody2D>();
                if (rb != null && rb.velocity.y <= 0.1f)
                {
                    AddJump(player);
                }
            }
        }

        private void AddJump(PlayerController player)
        {
            player.AddForce(new Vector2(0f, JumpForce));
            transform.DOPunchScale(new Vector3(0.5f, -0.4f), 0.2f);
        }
    }
}