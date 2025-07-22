using System;
using DG.Tweening;
using UnityEngine;

namespace Objects
{
    public class BulbPlaceAnimator : MonoBehaviour
    {
        private Animator _animator;
        public BulbPlace _bulbPlace;
        private Vector3 _initialScale;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _bulbPlace = GetComponent<BulbPlace>();
            _bulbPlace.ChangedBulb += BulbPlace_SetBulb;
            _initialScale = transform.localScale;
        }

        private void OnDestroy()
        {
            _bulbPlace.ChangedBulb -= BulbPlace_SetBulb;
        }

        private void BulbPlace_SetBulb(bool present)
        {
            transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), 0.2f)
                .OnComplete(() => transform.localScale = _initialScale);
            if (_animator) _animator.SetBool("Bulb", present);
        }
    }
}