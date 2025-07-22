using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class SceneTeleportTrigger : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerController>(out var player))
            {
                StartCoroutine(LoadSequence());
            }
        }

        private IEnumerator LoadSequence()
        {
            // Screen shake
            PlayerInputSystem.Instance.BlockInput();
            Blackout.Instance.FadeIn();
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            yield return new WaitForSeconds(0.3f);

            Blackout.Instance.FadeOut();
            PlayerInputSystem.Instance.UnblockInput();
        }
    }
}