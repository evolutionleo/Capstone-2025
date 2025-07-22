using System;
using UnityEngine;

namespace Objects
{
    public class StartLevelSoundTrack : MonoBehaviour
    {
        public string audioName;
        private void Start()
        {
            AudioManager.instance.Play(audioName);
        }

        private void OnDestroy()
        {
            AudioManager.instance.StopPlaying(audioName);
        }
    }
}