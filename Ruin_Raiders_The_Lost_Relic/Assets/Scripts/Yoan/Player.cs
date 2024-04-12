using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

namespace fym
{
    public class Player : Character
    {

        private Rigidbody2D _rb;
        private CapsuleCollider2D _capsuleCollider;
        private bool _canDoubleJump = false;
        private bool _canDash = true;
        private bool _isFacingRight = true;

        [SerializeField] protected int _dashStrength;
        private float _moveDirection;

        private bool _isJumping;
        private bool _isDashing;
        private bool _isMoving;
        private bool _isAttacking;
        private bool _isGrounded;


        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;



        // Start is called before the first frame update
        void Start()
        {

            Time.timeScale = 1;
            InputHandler.instance.moveEvent += Movement;
            InputHandler.instance.jumpEvent += Jump;
            InputHandler.instance.dashEvent += Dash;
            InputHandler.instance.attackEvent += Attack;
            enabled = true;

            //le Rigidbody2D est attaché au GameObject du joueur
            _rb = GetComponent<Rigidbody2D>();
        }



        IEnumerator waitDashTime()
        {
            yield return new WaitForSeconds(0.2f);
            _isDashing = false;
        }

        IEnumerator waitAttackTime()
        {
            yield return new WaitForSeconds(0.01f);
            _isAttacking = false;
        }


        void FixedUpdate()
        {
            GroundCheck();
            ApplyMove();
            FacingDirection();
        }

        public override void Movement(float x)
        {
            // Tells which direction the player moves
            _moveDirection = x;

            /*if (x == 0)
            {
                enabled = false;
                return;
            }

            enabled = true;*/

            if (_moveDirection != 0 && !_isJumping)
            {
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }
        }

        private void ApplyMove()
        {
            if (!_isDashing)
            {
                //movement of the player
                _rb.velocity = new Vector2(_moveDirection * _speed, _rb.velocity.y);
            }
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
            if (_isGrounded)
            {
                // Add an up force to simulate Jump
                //_rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength);
                
                    _isJumping = true;

            }
            else if (!_isGrounded && _canDoubleJump && InputHandler._JumpContext == "Started")
            {

                //_rb.AddForce(Vector2.up * _jumpStrength * 3f, ForceMode2D.Impulse);
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpStrength);
                _canDoubleJump = false;
                
                _isJumping = true;
            }
        }



        public override void Attack()
        {
            _isAttacking = true;
            StartCoroutine(waitAttackTime());
        }

        private void Dash()
        {
            //GroundCheck to enable dash if grounded
            GroundCheck();
            // Verify if the player is grounded and than change the velocity to dash to the new direction
            if (_isGrounded)
            {
                _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
                _isDashing = true;
                StartCoroutine(waitDashTime());
            }
            else if (!_isGrounded && _canDash)
            {
                _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
                _canDash = false;
                _isDashing = true;
                StartCoroutine(waitDashTime());
            }
            //Debug.Log("Dash");
        }

        private void GroundCheck()
        {
            if (Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer))
            {
                _isGrounded = true;
                _canDash = true;
                _canDoubleJump = true;
                _isJumping = false;
            }
            else
            {
                _isGrounded = false;
            }
        }

        public bool IsGrounded
        {

            get { return _isGrounded; }

        }

        public bool IsJumping
        {
            set { _isJumping = value; }
            get { return _isJumping; }
        }

        public bool IsMoving
        {
            set { _isMoving = value; }
            get { return _isMoving; }
        }

        public bool IsAttacking
        {
            set { _isAttacking = value; }
            get { return _isAttacking; }
        }

        public bool IsDashing
        {
            set { _isDashing = value;}
            get { return _isDashing; }
        }
    }
 }   



