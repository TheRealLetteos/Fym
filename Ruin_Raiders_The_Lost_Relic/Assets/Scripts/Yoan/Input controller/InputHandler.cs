using fym;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, MainInputs.IPlayerMovementsActions
{
    public delegate void MoveEvent(float x);
    public delegate void JumpEvent();
    public delegate void DashEvent();

    public delegate void AttackEvent();

    public delegate void InventoryEvent();

    public event MoveEvent moveEvent;
    public event JumpEvent jumpEvent;
    public event DashEvent dashEvent;

    public event AttackEvent attackEvent;

    public event InventoryEvent inventoryEvent;

    public static InputHandler instance;
    public static string _JumpContext;  
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
        //Debug.Log(context.phase);
        _JumpContext = context.phase.ToString();
        jumpEvent?.Invoke();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        //Debug.Log(context.phase);
        dashEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        
            moveEvent?.Invoke(context.ReadValue<float>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attackEvent?.Invoke();
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        inventoryEvent?.Invoke();
    }
    
}
