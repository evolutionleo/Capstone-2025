using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public static PlayerInputSystem Instance { get; private set; }

    private bool _blocked = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void BlockInput()
    {
        _blocked = true;
        Debug.Log("Blocked player input");
    }

    public void UnblockInput()
    {
        Debug.Log($"Before unlocking player input {_blocked}");
        _blocked = false;
        Debug.Log("Unblocked player input");
    }

    public float GetHorizontal()
    {
        return _blocked ? 0f : Input.GetAxisRaw("Horizontal");
    }

    public float GetVertical()
    {
        return _blocked ? 0f : Input.GetAxisRaw("Vertical");
    }

    public bool JumpPressed()
    {
        return !_blocked && (Input.GetButtonDown("Jump"));
    }

    public bool JumpHeld()
    {
        return !_blocked && (Input.GetButton("Jump") );
    }

    public bool InteractPressed()
    {
        return !_blocked && Input.GetKeyDown(KeyCode.E);
    }

    public bool InteractHeld()
    {
        return !_blocked && Input.GetKey(KeyCode.E);
    }

    public bool Interact2Held()
    {
        return !_blocked && Input.GetKey(KeyCode.Q);
    }

    public bool UpPressed()
    {
        return !_blocked && (Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("Vertical") > 0.5f);
    }
}
