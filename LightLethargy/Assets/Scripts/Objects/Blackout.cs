using System;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class Blackout : MonoBehaviour
    {
        public CanvasGroup CanvasGroup;

        public static Blackout Instance;

        private void Awake()
        {
            if (Instance!=null)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;
        }

        public void FadeIn()
        {
            CanvasGroup.DOFade(1f, 0.2f);
        }
        public void FadeOut()
        {
            CanvasGroup.DOFade(0f, 0.2f);
        }
    }
}
