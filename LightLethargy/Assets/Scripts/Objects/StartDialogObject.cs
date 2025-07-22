using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class StartDialogObject : MonoBehaviour
    {
        public List<DialogReplic> dialogs;

        public float pauseBetweenReplics;

        public CinemachineVirtualCamera camera;

        public void Shake(float shake)
        {
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shake;
            camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = shake;
        }

        private IEnumerator Start()
        {
#if !UNITY_EDITOR
            yield return new WaitForSeconds(1.5f);
            foreach (var dialog in dialogs)
            {
                dialog.Event?.Invoke();
                yield return new WaitForSeconds(dialog.additionalStartPause);
                yield return dialog.dialogObject.PlayDialog(dialog.text);
                yield return new WaitForSeconds(pauseBetweenReplics);
                dialog.dialogObject.Clear();
            }
#endif
            Blackout.Instance.FadeInstantly(1);
            yield return null;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}