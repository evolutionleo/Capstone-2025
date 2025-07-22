using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Cinemachine;
using Objects;

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
        StartCoroutine(DeathSequence());
    }

    private IEnumerator ProcessShake(float shakeIntensity = 5f, float shakeTiming = 0.2f)
    {
        var cam = FindObjectOfType<CinemachineVirtualCamera>();
        var noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        Noise(noise, 1, shakeIntensity);
        yield return new WaitForSeconds(shakeTiming);
        Noise(noise, 0, 0);
    }

    public void Noise(CinemachineBasicMultiChannelPerlin noise, float amplitudeGain, float frequencyGain)
    {
        noise.m_AmplitudeGain = amplitudeGain;
        noise.m_FrequencyGain = frequencyGain;
    }

    private IEnumerator DeathSequence()
    {
        // Screen shake
        PlayerInputSystem.Instance.BlockInput();
        StartCoroutine(ProcessShake());
        yield return new WaitForSeconds(0.3f);

        Blackout.Instance.FadeIn();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene( SceneManager.GetActiveScene().name);

        yield return new WaitForSeconds(0.4f);

        Blackout.Instance.FadeOut();

        PlayerInputSystem.Instance.UnblockInput();
    }
}