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
        private bool _canDoubleJump = false;
        private bool _canDash = true;
        private bool _isFacingRight = true;

        [SerializeField] private TrailRenderer _tr;
        [SerializeField] protected int _dashStrength;
        private float _moveDirection;
        
        //Character State variable
        private bool _isJumping;
        private bool _isDashing;
        private bool _isMoving;
        private bool _isAttacking;
        private bool _isGrounded;
        
        //Sound
        [SerializeField] private AudioSource _audioWalkingSource;
        [SerializeField] private AudioSource _audioShortSource;
        [SerializeField] private AudioClip _attackClip;
        [SerializeField] private AudioClip _dashClip;
        [SerializeField] private AudioClip _jumpClip;


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

            //Get player rigidbody
            _rb = GetComponent<Rigidbody2D>();
        }


        
        IEnumerator WaitDashTime()
        {
            yield return new WaitForSeconds(0.2f);
            _isDashing = false;
            _tr.emitting = false;
        }

        IEnumerator WaitAttackTime()
        {
            yield return new WaitForSeconds(0.01f);
            _isAttacking = false;
        }


        void FixedUpdate()
        {
            FUGroundCheck();
            FUApplyMove();
            FUChangingMovingDirection();
        }

        public override void Movement(float x)
        {
            // Tells which direction the player moves
            _moveDirection = x;
            Debug.Log(x);
            
        }

        private void FUApplyMove()
        {
            if (!_isDashing)
            {
                //movement of the player
                _rb.velocity = new Vector2(_moveDirection * _speed, _rb.velocity.y);
            }
            
            //walking sound
            if (_moveDirection != 0 && _isGrounded)
            {
                _isMoving = true;
                if (!_audioWalkingSource.isPlaying)
                {
                    _audioWalkingSource.Play();
                }
            }
            else
            {
                _isMoving = false;
               _audioWalkingSource.Stop();
            }
        }

        
        private void FUChangingMovingDirection()
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
            
            FUGroundCheck();
            if (_isGrounded)
            {
                //Changing the velocity to go higher
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
                _isJumping = true;
                _audioWalkingSource.Stop();
                _audioShortSource.clip = _jumpClip;
                _audioShortSource.Play();
            }
            else if (!_isGrounded && _canDoubleJump && InputHandler._JumpContext == "Started")
            {

                //Making a new velocity so it doesn't add up(better feeling)
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
                _canDoubleJump = false;
                _isJumping = true;
                _audioShortSource.clip = _jumpClip;
                _audioShortSource.Play();
            }
        }



        public override void Attack()
        {
            //To do: implementing a when the player hit the enemy and the effect of it
            _isAttacking = true;
            StartCoroutine(WaitAttackTime());
        }

        private void Dash()
        {
            //GroundCheck to enable dash if grounded
            FUGroundCheck();
            // Verify if the player is grounded and than change the velocity to dash to the new direction
            if (_isGrounded)
            {
                
                _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
                _isDashing = true;
                _tr.emitting = true;
                _audioShortSource.clip = _dashClip;
                _audioShortSource.Play();
                StartCoroutine(WaitDashTime());
            }
            else if (!_isGrounded && _canDash)
            {
                float _originalGravity = _rb.gravityScale;
                _rb.gravityScale = 0f;
                _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
                _canDash = false;
                _isDashing = true;
                _tr.emitting = true;
                _audioShortSource.clip = _dashClip;
                _audioShortSource.Play();
                StartCoroutine(WaitDashTime());
                _rb.gravityScale = _originalGravity;
            }
            //Debug.Log("Dash");
        }

        private void FUGroundCheck()
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
        
        private void PlayAttackSound()
        {
            _audioShortSource.clip = _attackClip;
            _audioShortSource.Play();
        }

        //Get Set of the state
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



