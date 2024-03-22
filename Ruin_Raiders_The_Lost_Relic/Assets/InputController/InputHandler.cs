using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, MainInputs.IPlayerMovementsActions
{
    public delegate void MoveEvent();
    public delegate void JumpEvent();
    public delegate void DashEvent();

    public event MoveEvent moveEvent;
    public event JumpEvent jumpEvent;
    public event DashEvent dashEvent;

    public static InputHandler instance;
        
    private MainInputs _mInputs;
        
        
    void Awake()
    {
        if(instance != null)
        {
            instance?.KillInstance();
            return;
        }

        instance ??= this;
        _mInputs = new MainInputs();
    }

    private void Start()
    {
        _mInputs.PlayerMovements.SetCallbacks(this);
    }

    private void OnEnable()
    {
        _mInputs.Enable();
    }

    private void OnDisable()
    {
        _mInputs.Disable();
    }

    private void KillInstance()
    {
        Destroy(this);
    }


    public void OnJump(InputAction.CallbackContext context)
    {
           Debug.Log(context.phase);
        //jumpEvent?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log(context.phase);
        //moveEvent?.Invoke();
    }
    
}
