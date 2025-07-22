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

    private void Start()
    {
        _animator = GetComponent<Animator>();
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
        HandleInput();
        SetAnimator();
        if (!LampInHead)
        {
            timeWithoutLamp += Time.deltaTime;
            if (timeWithoutLamp >= timeWithoutLampToDie)
            {
                DeathHandler.Instance.KillPlayer();
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (LampInHead)
                DropLampFromHead();
            else
                PickLampToHead();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LampInHand)
                DropLampFromHand();
            else 
                PickLampToHand();
        }
    }

    public void PickLampToHead()
    {
        LampInHead = true;
    }

    public void DropLampFromHead()
    {
        LampInHead = false;
    }

    public void PickLampToHand()
    {
        LampInHand = true;
    }

    public void DropLampFromHand()
    {
        LampInHand = false;
    }
}