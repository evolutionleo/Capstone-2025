using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class DoOnPlayerEnter : MonoBehaviour
{
    [FormerlySerializedAs("_object")] [SerializeField] private MonoBehaviour _objectToEnable;
    [SerializeField] private bool _oneShot = true;
    [SerializeField] private UnityEvent _event;

    private bool _hasFired = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (_oneShot && !_hasFired || !_oneShot)
            {
                _objectToEnable.enabled = true;
                _event.Invoke();
            }
        }
    }
}
