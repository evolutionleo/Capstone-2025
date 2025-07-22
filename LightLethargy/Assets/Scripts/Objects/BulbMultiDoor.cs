using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class BulbMultiDoor : MonoBehaviour
    {
        public List<BulbPlace> BulbPlaces;
        public Transform DoorTransform;
        public Vector3 OpenValue = new Vector3(1, 1, 1);
        public Vector3 ClosedValue = new Vector3(0, 1, 1);
        public float AnimationSpeed = 0.3f;

        private void Awake()
        {
            foreach (var bulbPlace in BulbPlaces)
            {
                bulbPlace.ChangedBulb += OnBulbChanged;
            }

            UpdateDoor();
        }

        private void OnDestroy()
        {
            foreach (var bulbPlace in BulbPlaces)
            {
                bulbPlace.ChangedBulb -= OnBulbChanged;
            }
        }

        private void OnBulbChanged(bool _)
        {
            UpdateDoor();
        }

        private void UpdateDoor()
        {
            bool anyOff = BulbPlaces.Any(bp => !bp.HasBulb);
            Debug.Log(anyOff);
            DoorTransform.DOKill();
            DoorTransform.DOScale(anyOff ? ClosedValue : OpenValue, AnimationSpeed).SetEase(Ease.InOutSine);
        }
    }
}