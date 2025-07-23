using Objects;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class L2S1_Thrower : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity1;
    [SerializeField] private Vector3 _force2;
    [SerializeField] private Collider2D _trigger;
    [SerializeField] private PlayerController _controller;
    [SerializeField] private Collider2D _deathZone;
    [SerializeField] private StartDialogObject _dialog;
    [SerializeField] private GameObject _dialogDisplay;
    [SerializeField] private Vector2 _dialogDisplayOffset1;
    [SerializeField] private Vector2 _dialogDisplayOffset2;
    
    private Rigidbody2D _rigidbody2D;
    private bool _hasFired;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _controller.enabled = false;
        _deathZone.enabled = false;
    }

    private void Start()
    {
        _rigidbody2D.velocity = _velocity1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_hasFired && other == _trigger)
        {
            _rigidbody2D.AddForce(_force2, ForceMode2D.Impulse);
            _hasFired = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _deathZone.enabled = true;
            _controller.enabled = true;
            _dialog.enabled = true;
        }
    }

    public void LockMovement()
    {
        _controller.enabled = false;
        Debug.Log("Disabled player controller");
    }

    public void EnabledMovement()
    {
        _controller.enabled = true;
        Debug.Log("Enabled player controller");
    }
}
