using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.UI;

namespace fym
{
    public class Player : Character
    {

        private Rigidbody2D _rb;
        private bool _canDoubleJump = false;
        private bool _canDash = true;
        private bool _isFacingRight = true;
        private Color _spriteColor;
        private Renderer _rend;

        [SerializeField] private TrailRenderer _tr;
        [SerializeField] protected int _dashStrength;
        [SerializeField] private float _repulsionForce;
        [SerializeField] private float _gravity;
        private Vector2 _vecGravity;
        [SerializeField] private float _attackRange = 1.5f;
        [SerializeField] private LayerMask _enemyLayer;
        private RaycastHit2D[] _hits;
        [SerializeField] private Transform _attackTransform;
        private float _moveDirection;
        
        //Character State variable
        private bool _isJumping;
        private bool _isDashing;
        private bool _isMoving;
        private bool _isAttacking;
        private bool _isGrounded;
        private bool _isDead;
        private bool _isHurt;
        private bool _isInventory;
        private bool _movementEnabled = true;
        
        //Sound
        [SerializeField] private AudioSource _audioWalkingSource;
        [SerializeField] private AudioSource _audioShortSource;
        [SerializeField] private AudioClip _attackClip;
        [SerializeField] private AudioClip _dashClip;
        [SerializeField] private AudioClip _jumpClip;


        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        
        private GameObject _restartUI;
        private GameObject _inventoryUI;
        private Image[] hearts;


        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            InputHandler.instance.moveEvent += Movement;
            InputHandler.instance.jumpEvent += Jump;
            InputHandler.instance.dashEvent += Dash;
            InputHandler.instance.attackEvent += Attack;
            InputHandler.instance.inventoryEvent += Inventory;
            enabled = true;

            //Get player rigidbody
            _rb = GetComponent<Rigidbody2D>();
            _rend = GetComponent<Renderer>();
            _spriteColor = _rend.material.color;
            
            GameObject healthParent = GameObject.Find("Health");
            hearts = new Image[3];
            for (int i = 0; i < hearts.Length; i++)
            {
                Transform heartTransform = healthParent.transform.Find("Heart" + (i + 1));
                hearts[i] = heartTransform.GetComponent<Image>();
            }
            GameObject canvasObject = GameObject.Find("Canvas");
            Transform inventoryUITransform = canvasObject.transform.Find("Inventory");
            _inventoryUI = inventoryUITransform.gameObject;
            Transform restartUITransform = canvasObject.transform.Find("ReplayScreen");
            _restartUI = restartUITransform.gameObject;

            _life = 3;
            UpdateHealth();
        }

        private void Update()
        {
            if (_rb.velocity.y < 0)
            {
                _rb.velocity += Vector2.up * Physics2D.gravity.y * (_gravity - 1) * Time.deltaTime;
            }
        }

        private void Inventory()
        {
            if (!_isInventory)
            {
                _inventoryUI.SetActive(true);
                _isInventory = true;
            }
            else if (_isInventory)
            {
                _inventoryUI.SetActive(false);
                _isInventory = false;
            }
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

        IEnumerator WaitHurtTime()
        {
            Physics2D.IgnoreLayerCollision(8, 10, true);
            _spriteColor.a = 0.5f;
            _rend.material.color = _spriteColor;
            yield return new WaitForSeconds(0.5f);
            _isHurt = false;
            yield return new WaitForSeconds(1.5f);
            Physics2D.IgnoreLayerCollision(8, 10, false);
            _spriteColor.a = 1f;
            _rend.material.color = _spriteColor;
            
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
            //Debug.Log(x);
            
        }

        private void FUApplyMove()
        {
            if (!_isDashing &&   _movementEnabled)
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
            if (_isGrounded && !_isDead)
            {
                //Changing the velocity to go higher
                _rb.velocity = new Vector2(_rb.velocity.x, 0);
                _rb.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
                _isJumping = true;
                _audioWalkingSource.Stop();
                _audioShortSource.clip = _jumpClip;
                _audioShortSource.Play();
            }
            else if (!_isGrounded && _canDoubleJump && InputHandler._JumpContext == "Started" && !_isDead)
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
            if (!_isDead)
            {
                _isAttacking = true;

                _hits = Physics2D.CircleCastAll(_attackTransform.position, _attackRange,transform.right, 0f, _enemyLayer);
                
                for (int i = 0; i < _hits.Length; i++)
                {
                   Debug.Log("Enemy hit");
                   //MAO
                   //Script to acces the Enemy
                   //Ex: Enemy _enemyScript = enemy.GetComponentInChildren
                   //enemyScript.TakeDamage(attackDamage);
                   Collider2D enemyCollider = _hits[i].collider;
                   BaseEnemyController _enemy = enemyCollider.GetComponent<BaseEnemyController>();
                   if (_enemy != null)
                   {
                       _enemy.GetComponent<BaseEnemyController>().TakeDamage(1);
                   }
                }
                StartCoroutine(WaitAttackTime());
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(_attackTransform.position, _attackRange);
        }

        private void Dash()
        {
            //GroundCheck to enable dash if grounded
            FUGroundCheck();
            // Verify if the player is grounded and than change the velocity to dash to the new direction
            if (_isGrounded && !_isDead)
            {
                
                _rb.velocity = new Vector2(transform.localScale.x * _dashStrength, 0f);
                _isDashing = true;
                _tr.emitting = true;
                _audioShortSource.clip = _dashClip;
                _audioShortSource.Play();
                StartCoroutine(WaitDashTime());
            }
            else if (!_isGrounded && _canDash && !_isDead)
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
        
        public void UpdateHealth()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < _life)
                {
                    hearts[i].color = Color.white;
                }
                else
                {
                    hearts[i].color = Color.black;
                }
            }
            
        }

        private void Hurt(int damage)
        {
            
                _life -= damage;
                UpdateHealth();
                if (_life <= 0)
                {
                    Die();
                }

                _isHurt = true;
                StartCoroutine(WaitHurtTime());
            
        }
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // Réduit la santé du joueur lorsque collision avec un ennemi
                Hurt(1);

                _movementEnabled = false;
                
                Vector2 recoilDirection = (transform.position - collision.transform.position).normalized;
                _rb.AddForce(recoilDirection * _repulsionForce, ForceMode2D.Impulse);
                
                Invoke("EnableControls", 0.5f);
            }
            if (collision.gameObject.CompareTag("Item"))
            {
                // Détruire l'objet en collision
                IPickable pickableItem = collision.gameObject.GetComponent<IPickable>();
                if (pickableItem != null)
                {
                    pickableItem.AddPickable();
                }
                Destroy(collision.gameObject);
            }
        }

        private void EnableControls()
        {
            _movementEnabled = true;
        }
        void Die()
        {
            _isDead = true;
            _audioWalkingSource.Stop();
            // Ici tu peux déclencher l'animation de mort ou d'autres actions
            Debug.Log("Player is dead.");
            _restartUI.SetActive(true);
            enabled = false;
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

        public bool IsHurt
        {
            get { return _isHurt;}
        }

        public bool IsDead
        {
            get { return _isDead; }
        }
    }
 }   



