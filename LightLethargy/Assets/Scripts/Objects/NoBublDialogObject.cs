using System;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class NoBublDialogObject : MonoBehaviour
    {
        public List<DialogReplic> dialogs;

        private bool _startedReplic;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (_startedReplic) return;

            if (other.TryGetComponent(out PlayerController player))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerInputSystem.Instance.BlockInput();
                    _startedReplic = true;
                    dialogs[_currentIndex].dialogObject.Play(dialogs[_currentIndex].text);
                }
            }
        }

        private int _currentIndex;

        private void Update()
        {
            if (Input.anyKeyDown && _startedReplic)
            {
                dialogs[_currentIndex].dialogObject.Stop();
                _currentIndex++;
                if (_currentIndex >= dialogs.Count)
                {
                    PlayerInputSystem.Instance.UnblockInput();
                }
            }
        }
    }
}