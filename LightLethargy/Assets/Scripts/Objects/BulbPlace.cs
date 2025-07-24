using System;
using UnityEngine;
using UnityEngine.Events;

namespace Objects
{
    public class BulbPlace : MonoBehaviour
    {
        public bool HasBulb;
        public Action<bool> ChangedBulb;
        public bool CanRemoveBulb = true;
        public bool CanPlaceBulb = true;

        [SerializeField] private UnityEvent onBulbInstalled;
        [SerializeField] private UnityEvent onTryInstallingBulb;

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
            onBulbInstalled.Invoke();
        }

        public void InteractWithPlayer(LampHandler player)
        {
            if (!PlayerInputSystem.Instance.InteractHeld())
            {
                return;
            }
            
            if (HasBulb && player.CanInteract() && CanRemoveBulb)
            {
                if (!player.LampInHand)
                {
                    player.PickLampToHand(null);
                    RemoveBulb();
                }
            }
            else if (player.LampInHand && player.CanInteract())
            {
                if (CanPlaceBulb)
                {
                    player.RemoveBulbFromHand();
                    SetBulb();
                }
                else
                {
                    onTryInstallingBulb.Invoke();
                }
            }
        }
        
        public void SetCanPlaceBulb(bool canPlaceBulb) => CanPlaceBulb = canPlaceBulb;
    }
}