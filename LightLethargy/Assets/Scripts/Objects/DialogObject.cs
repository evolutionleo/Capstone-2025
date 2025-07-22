using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Objects
{
    public class DialogObject : MonoBehaviour
    {
        public BulbPlace BulbPlace;

        private bool _startedDialog;

        public List<DialogReplic> dialogs;

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
            if (_startedDialog) return;
            if (enabled)
            {
                PlayerInputSystem.Instance.BlockInput();
                _startedDialog = true;
                dialogs[_currentIndex].dialogObject.Play(dialogs[_currentIndex].text);
            }
        }

        private int _currentIndex;

        private void Update()
        {
            if (Input.anyKeyDown && _startedDialog)
            {
                dialogs[_currentIndex].dialogObject.Stop();
                _currentIndex++;
                if (_currentIndex >= dialogs.Count)
                {
                    PlayerInputSystem.Instance.UnblockInput();
                    BulbPlace.RemoveBulb();
                    BulbSpawner.SpawnBulb(transform.position);
                }
                else
                {
                    dialogs[_currentIndex].dialogObject.Play(dialogs[_currentIndex].text);
                }
            }
        }
    }

    [Serializable]
    public class DialogReplic
    {
        public UnityEvent Event;
        public DialogPlayer dialogObject;
        public float additionalStartPause;
        public string text;
        public float additionalEndPause;
    }
}