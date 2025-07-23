using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class StartDialogObject : MonoBehaviour
    {
        public List<DialogReplic> dialogs;

        public float pauseBetweenReplics;

        public CinemachineVirtualCamera camera;
        public UnityEvent StartEvent;
        public UnityEvent FinishEvent;

        public bool skip;

        public void Shake(float shake)
        {
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shake;
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = shake;
        }

        private IEnumerator Start()
        {
            StartEvent?.Invoke();
            if (!skip)
            {
                yield return new WaitForSeconds(1.5f);
                foreach (var dialog in dialogs)
                {
                    dialog.Event?.Invoke();
                    yield return new WaitForSeconds(dialog.additionalStartPause);
                    Debug.Log(dialog.text);
                    yield return dialog.dialogObject.PlayDialog(dialog.text);
                    yield return new WaitForSeconds(pauseBetweenReplics);
                    yield return new WaitForSeconds(dialog.additionalEndPause);
                    dialog.dialogObject.Clear();
                }
            }

            yield return null;
            FinishEvent?.Invoke();
        }

        public void BlockInput()
        {
            PlayerInputSystem.Instance.BlockInput();
        }

        public void UnblockInput()
        {
            PlayerInputSystem.Instance.UnblockInput();
        }

        public void FadeBlockout()
        {
            Blackout.Instance.FadeInstantly(1);
        }

        public void NextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}