using System;
using UnityEngine;

namespace Objects
{
    public class StartLevelSoundTrack : MonoBehaviour
    {
        public string audioName;
        public string stopSoundName;
        public bool needToBlackout = true;

        private void Start()
        {
            AudioManager.instance.Play(audioName);
            if (needToBlackout)
                Blackout.Instance.FadeOut();
        }

        private void OnDestroy()
        {
            AudioManager.instance.StopPlaying(stopSoundName);
        }
    }
}