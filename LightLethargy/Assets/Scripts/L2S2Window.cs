using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Events;

public class L2S2Window : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _picture;
    [SerializeField] private SpriteRenderer _dimmer;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private UnityEvent _onFinished;

    private void Start() => StartCoroutine(DoTheThing());

    private IEnumerator DoTheThing()
    {
        PlayerInputSystem.Instance.BlockInput();
        
        var follow = _camera.Follow;
        _camera.Follow = _picture.transform;

        
        for (var i = 0; i < 60; i++)
        {
            var dimmerAlpha = _dimmer.color.a + 0.75f / 60;
            _dimmer.color = new Color(_dimmer.color.r, _dimmer.color.g, _dimmer.color.b, dimmerAlpha);
            var pictureAlpha = _picture.color.a + 1f / 60;
            _picture.color = new Color(_picture.color.r, _picture.color.g, _picture.color.b, pictureAlpha);
            yield return new WaitForSeconds(1f / 60f);
        }
        
        yield return new WaitUntil(() => Input.anyKeyDown);
        
        for (var i = 0; i < 60; i++)
        {
            var dimmerAlpha = _dimmer.color.a - 0.75f / 60;
            _dimmer.color = new Color(_dimmer.color.r, _dimmer.color.g, _dimmer.color.b, dimmerAlpha);
            var pictureAlpha = _picture.color.a - 1f / 60;
            _picture.color = new Color(_picture.color.r, _picture.color.g, _picture.color.b, pictureAlpha);
            yield return new WaitForSeconds(1f / 60f);
        }

        _camera.Follow = follow;
        PlayerInputSystem.Instance.UnblockInput();
        _onFinished.Invoke();
    }
}
