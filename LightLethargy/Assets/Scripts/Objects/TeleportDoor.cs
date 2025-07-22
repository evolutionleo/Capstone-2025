using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class TeleportDoor : MonoBehaviour
    {
        public TeleportDoor PairedDoor;
        public float TeleportDelay = 0.2f;
        public float Cooldown = 0.5f;

        private bool _canTeleport = true;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!_canTeleport) return;
            if (other.TryGetComponent<PlayerController>(out var player))
            {
                if (PlayerInputSystem.Instance.UpPressed())
                {
                    StartCoroutine(TeleportWithDelay(player));
                }
            }
        }

        private IEnumerator TeleportWithDelay(PlayerController player)
        {
            _canTeleport = false;
            yield return new WaitForSeconds(TeleportDelay);
            if (PairedDoor && PairedDoor.transform)
            {
                PlayerInputSystem.Instance.BlockInput();
                player.transform.position = PairedDoor.transform.position;
                PairedDoor.StartCoroutine(PairedDoor.TeleportCooldown());
            }
            player.transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.2f);
            yield return new WaitForSeconds(Cooldown);
            PlayerInputSystem.Instance.UnblockInput();
            _canTeleport = true;
        }

        private IEnumerator TeleportCooldown()
        {
            _canTeleport = false;
            yield return new WaitForSeconds(Cooldown);
            _canTeleport = true;
        }
    }
}