using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Objects
{
    [Serializable]
    public class DialogPlayer : MonoBehaviour
    {
        public TMP_Text dialogText;
        public float speed;

        private Coroutine _coroutine;

        public void Play(string text)
        {
            _coroutine = StartCoroutine(PlayDialog(text));
        }

        public IEnumerator PlayDialog(string text)
        {
            dialogText.text = "";
            foreach (var t in text)
            {
                dialogText.text += t;
                yield return new WaitForSeconds(1 / speed);
            }

            yield return null;
        }

        public void Stop()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }

        public void Clear()
        {
            dialogText.text = "";
        }
    }
}