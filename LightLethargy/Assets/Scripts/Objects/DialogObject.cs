using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

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
            }
        }

        public IEnumerator PlayDialog()
        {
            PlayerInputSystem.Instance.BlockInput();
            foreach (var replic in dialogs)
            {
                
            }

            BulbPlace.RemoveBulb();
            BulbSpawner.SpawnBulb(transform.position);
            PlayerInputSystem.Instance.UnblockInput();
            yield return null;
        }
    }

    public class DialogReplic
    {
        public DialogObject dialogObject;
        public string text;
    }
}