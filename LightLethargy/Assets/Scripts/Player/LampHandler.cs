using UnityEngine;

public class LampHandler : MonoBehaviour
{
    public static LampHandler Instance { get; private set; }

    public bool HasLamp => LampInHead || LampInHand;
    public bool LampInHead { get; private set; }
    public bool LampInHand { get; private set; }

    [SerializeField] private float timeWithoutLampToDie = 5f;
    private float timeWithoutLamp;

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

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (LampInHead)
                DropLampFromHead();
            else if (HasLamp)
                PickLampToHead();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LampInHand)
                DropLampFromHand();
            else if (HasLamp)
                PickLampToHand();
        }
    }

    public void PickLampToHead()
    {
        LampInHead = true;
        LampInHand = false;
    }

    public void DropLampFromHead()
    {
        LampInHead = false;
    }

    public void PickLampToHand()
    {
        LampInHand = true;
        LampInHead = false;
    }

    public void DropLampFromHand()
    {
        LampInHand = false;
    }
}