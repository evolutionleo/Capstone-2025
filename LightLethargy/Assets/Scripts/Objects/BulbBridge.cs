using System;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class BulbBridge : MonoBehaviour
    {
        public BulbPlace BulbPlace;
        public Transform BridgeTransform;
        public Vector3 TurnedOnRotation;
        public Vector3 TurnedOffRotation;
        public float AnimationSpeed = 0.3f;

        private void Awake()
        {
            BulbPlace.ChangedBulb += BulbPlace_ChangedBulb;
        }

        private void OnDestroy()
        {
            BulbPlace.ChangedBulb -= BulbPlace_ChangedBulb;
        }

        private void BulbPlace_ChangedBulb(bool enabled)
        {
            if (enabled)
            {
                BridgeTransform.DOLocalRotate(TurnedOnRotation, AnimationSpeed).SetEase(Ease.InOutSine);
            }
            else
            {
                BridgeTransform.DOLocalRotate(TurnedOffRotation, AnimationSpeed).SetEase(Ease.InOutSine);
            }
        }
    }
} 