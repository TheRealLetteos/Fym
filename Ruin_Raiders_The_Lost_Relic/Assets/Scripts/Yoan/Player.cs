using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class Player : Character
{
    private Rigidbody2D _rb;
    private bool _canDoubleJump = false;
    private bool _canDash = true;
    private bool _isFacingRight = true;
    private bool _isDashing = false;
    [SerializeField] 
    protected int _dashStrength;
    private float _moveDirection;
    

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        InputHandler.instance.moveEvent += Movement;
        InputHandler.instance.jumpEvent += Jump;
        InputHandler.instance.dashEvent += Dash;
        enabled = false;
        
        //le Rigidbody2D est attaché au GameObject du joueur
        _rb = GetComponent<Rigidbody2D>();
    }

    IEnumerator waitDashTime()
    {
        yield return new WaitForSeconds(0.2f);
        _isDashing = false;
    }
    

    void FixedUpdate()
    {
        if (!_isDashing)
        {
            //movement of the player
            _rb.velocity = new Vector2(_moveDirection * _speed, _rb.velocity.y);
        }
        FacingDirection();
    }

    public override void Movement(float x)
    {
        // Tells which direction the player moves
        _moveDirection = x;

        
            
        if (x == 0)
        {
            enabled = false;
            return;
        }

        enabled = true;
    }

    private void FacingDirection()
    {
        if (_isFacingRight && _moveDirection < 0f || !_isFacingRight && _moveDirection > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 _localScale = transform.localScale;
            _localScale.x *= -1f;
            transform.localScale = _localScale;
        }
    }

    public override void Jump()
    {
        GroundCheck();
        if (IsGrounded())
        {
            // Add an up force to simulate Jump
            //_rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength);

        }
        else if (!IsGrounded() && _canDoubleJump && InputHandler._JumpContext == "Started")
        {
            
            //_rb.AddForce(Vector2.up * _jumpStrength * 3f, ForceMode2D.Impulse);
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength);
            _canDoubleJump = false;
        }
    }

    

    public override void Attack()
    {
        base.Attack();
    }

    private void Dash()
    {
        //GroundCheck to enable dash if grounded
        GroundCheck();
        // Verify if the player is grounded and than change the velocity to dash to the new direction
        if (IsGrounded())
        {
            _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
            _isDashing = true;
            StartCoroutine(waitDashTime());
        }
        else if (!IsGrounded() && _canDash)
        {
            _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
            _canDash = false;
            _isDashing = true;
            StartCoroutine(waitDashTime());
        }
        //Debug.Log("Dash");
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);   
    }

    private void GroundCheck()
    {
        if (IsGrounded())
        {
            _canDash = true;
            _canDoubleJump = true;
        }
    }

    
}
