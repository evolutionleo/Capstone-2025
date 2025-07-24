using System;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class BulbWall : MonoBehaviour
    {
        public BulbPlace BulbPlace;
        public Transform WallTransform;
        public bool IsInverted;
        public Vector2 Direction;
        public float AnimationSpeed = 0.3f;

        private Vector3 _initialScale;

        private void Awake()
        {
            _initialScale = WallTransform.localScale;
            
            if (IsInverted)
            {
                WallTransform.localScale = Direction;
            }
            
            BulbPlace.ChangedBulb += BulbPlace_ChangedBulb;
        }

        private void OnDestroy()
        {
            BulbPlace.ChangedBulb -= BulbPlace_ChangedBulb;
        }


        private void BulbPlace_ChangedBulb(bool enabled)
        {
            if (enabled )
            {
                if (IsInverted)
                {
                    WallTransform.DOScale(_initialScale, AnimationSpeed);
                }
                else
                {
                    WallTransform.DOScale(Direction, AnimationSpeed);
                }
            }
            else
            {
                if (IsInverted)
                {
                    WallTransform.DOScale(Direction, AnimationSpeed);
                }
                else
                {
                    WallTransform.DOScale(_initialScale, AnimationSpeed);
                }
            }
        }
    }
}