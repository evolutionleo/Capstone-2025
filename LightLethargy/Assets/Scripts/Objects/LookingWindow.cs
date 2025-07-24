using UnityEngine;

namespace Objects
{
    public class LookingWindow : MonoBehaviour
    {
        [SerializeField] private Animator _pictureAnimator;

        private bool _pictureShown;
        
        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            if (!_pictureShown && PlayerInputSystem.Instance.InteractPressed())
            {
                _pictureAnimator.SetBool("show", true);
                _pictureShown = true;
                PlayerInputSystem.Instance.BlockInput();
            }
        }

        private void Update()
        {
            if (_pictureShown && PlayerInputSystem.Instance.InteractDownRegardlessOfBlock())
            {
                _pictureAnimator.SetBool("show", false);
                _pictureShown = false;
                PlayerInputSystem.Instance.UnblockInput();
            }
        }
    }
}