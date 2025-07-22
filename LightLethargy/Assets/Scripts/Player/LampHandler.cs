using System;
using Objects;
using UnityEngine;

public class LampHandler : MonoBehaviour
{
    public static LampHandler Instance { get; private set; }

    public bool HasLamp => LampInHead || LampInHand;
    public bool LampInHead;
    public bool LampInHand;

    [SerializeField] private float timeWithoutLampToDie = 5f;
    private float timeWithoutLamp;
    private Animator _animator;
    private float dropCooldown = 0.1f;
    private float dropCooldownTimer = 0f;
    private bool _isEnabled = true;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void ReactToBulb(Bulb bulb)
    {
        if (PlayerInputSystem.Instance.Interact2Held() && !LampInHead)
        {
            PickLampToHead(bulb);
        }

        if (PlayerInputSystem.Instance.InteractHeld() && !LampInHand)
        {
            PickLampToHand(bulb);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bulb bulb))
        {
            ReactToBulb(bulb);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bulb bulb))
        {
            ReactToBulb(bulb);
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (dropCooldownTimer > 0f)
            dropCooldownTimer -= Time.deltaTime;
        HandleInput();
        SetAnimator();
        if (!LampInHead)
        {
            timeWithoutLamp += Time.deltaTime;
            if (timeWithoutLamp >= timeWithoutLampToDie)
            {
                DeathHandler.Instance.KillPlayer();
                timeWithoutLamp = -100000f;
            }
        }
        else
        {
            timeWithoutLamp = 0f;
        }
    }

    private void SetAnimator()
    {
        _animator.SetBool("Head", LampInHead);
        _animator.SetBool("Hands", LampInHand);
    }

    private void HandleInput()
    {
        if (!_isEnabled) return;
        if (PlayerInputSystem.Instance.InteractHeld())
        {
            if (LampInHand)
                DropLampFromHand();
        }

        if (PlayerInputSystem.Instance.Interact2Held())
        {
            if (LampInHead)
                DropLampFromHead();
        }
    }

    public void PickLampToHead(Bulb bulb)
    {
        if (!CanInteract()) return;
        Debug.Log("PickLampToHead");
        dropCooldownTimer = 0.2f;
        LampInHead = true;
        if (_animator) _animator.SetBool("Bulb", true);
        Destroy(bulb.RootGameObject);
    }

    public void DropLampFromHead()
    {
        if (!CanInteract()) return;
        Debug.Log("DropLampFromHead");
        dropCooldownTimer = 0.2f;
        LampInHead = false;
        if (_animator) _animator.SetBool("Bulb", false);
        BulbSpawner.SpawnBulb(transform.position);
    }

    public void PickLampToHand(Bulb bulb)
    {
        if (!CanInteract()) return;
        Debug.Log("PickLampToHand");
        dropCooldownTimer = 0.2f;
        LampInHand = true;
        if (_animator) _animator.SetBool("Bulb", true);
        if (bulb)
            Destroy(bulb.RootGameObject);
    }

    public void DropLampFromHand()
    {
        if (!CanInteract()) return;
        Debug.Log("DropLampFromHand");
        dropCooldownTimer = 0.2f;
        LampInHand = false;
        if (_animator) _animator.SetBool("Bulb", false);
        BulbSpawner.SpawnBulb(transform.position);
    }

    public bool CanInteract()
    {
        return (dropCooldownTimer <= 0f);
    }

    public void RemoveBulbFromHand()
    {
        if (!CanInteract()) return;
        dropCooldownTimer = 0.2f;
        LampInHand = false;
    }

    public void SetDropEnabled(bool value)
    {
        _isEnabled = value;
    }
}