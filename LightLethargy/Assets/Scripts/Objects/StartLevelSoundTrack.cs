using System;
using UnityEngine;

namespace Objects
{
    public class StartLevelSoundTrack : MonoBehaviour
    {
        public AudioClip clip;
        public AudioClip overridingClip;
        [SerializeField] private AudioSource source;

        private static StartLevelSoundTrack instance;
        
        private void Start()
        {
            if (instance != null)
            {
                if (instance.overridingClip == clip)
                {
                    Destroy(instance.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    return;
                }
            }

            instance = this;
            DontDestroyOnLoad(gameObject);

            source.clip = clip;
            source.Play();
        }

        private void OnDestroy()
        {
            source.Stop();
        }
    }
}
