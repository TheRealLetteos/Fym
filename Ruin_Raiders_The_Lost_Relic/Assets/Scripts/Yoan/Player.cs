using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        InputHandler.instance.moveEvent += Movement;
        InputHandler.instance.jumpEvent += Jump;
        InputHandler.instance.dashEvent += Dash;
        enabled = false;
    }

    public override void Movement()
    {
        Debug.Log("Move");
    }

    public override void Jump()
    {
        Debug.Log("Jump");
    }

    public override void Attack()
    {
        base.Attack();
    }

    private void Dash()
    {
        Debug.Log("Dash");
    }
}
