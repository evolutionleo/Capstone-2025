using System;
using UnityEngine;

namespace Objects
{
    public class BulbPlace : MonoBehaviour
    {
        public bool HasBulb;
        public Action<bool> ChangedBulb;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out LampHandler lampHandler))
            {
                lampHandler.SetDropEnabled(false);
                InteractWithPlayer(lampHandler);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out LampHandler lampHandler))
            {
                lampHandler.SetDropEnabled(false);
                InteractWithPlayer(lampHandler);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out LampHandler lampHandler))
            {
                lampHandler.SetDropEnabled(true);
            }
        }

        public void RemoveBulb()
        {
            HasBulb = false;
            ChangedBulb?.Invoke(false);
        }

        public void SetBulb()
        {
            HasBulb = true;
            ChangedBulb?.Invoke(true);
        }

        public void InteractWithPlayer(LampHandler player)
        {
            if (!Input.GetKey(KeyCode.E))
            {
                return;
            }

            if (HasBulb && player.CanInteract())
            {
                if (!player.LampInHand)
                {
                    player.PickLampToHand(null);
                    RemoveBulb();
                }
            }
            else if (player.LampInHand && player.CanInteract())
            {
                player.RemoveBulbFromHand();
                SetBulb();
            }
        }
    }
}