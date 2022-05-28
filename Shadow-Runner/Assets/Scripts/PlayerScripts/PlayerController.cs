using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState 
{
    idle,
    running,
    fighting,
    super,
    death
}

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private PlayerControls inputActions;

    [Header("Player State")]
    public PlayerState playerState;

    [Header("Player Position Settings")]
    [SerializeField] private VectorValue playerPosition;

    [Header("Player Movement")]
    private Vector3 directionChange;
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    [SerializeField] private FloatValue playerSpeedValue;
    [SerializeField] private FloatValue playerJumpValue;
    private float playerSpeed;
    private float playerJump;

    [Header("Player Layer Settings")]
    [SerializeField] private LayerMask groundGetLayer;
   
    [Header("Player Animation")]
    private Animator animator;

    [Header("Player Health")]
    [SerializeField] private FloatValue playerDeathCounter;

    [Header("Player Bool Checker")]
    public bool superIsPressed;


    private void Awake()
    {
        instance = this;
        inputActions = new PlayerControls();
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    #region Enable and Disable Controllers
    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        animator.SetFloat("moveX", 1);
        playerState = PlayerState.idle;
        playerSpeed = playerSpeedValue.runtimeValue;
        playerJump = playerJumpValue.runtimeValue;
        playerPosition.startingPosition = transform.position;
        superIsPressed = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckState();
    }

    private void FixedUpdate()
    {
        CheckMovement();
    }

    private void CheckState() 
    {
        if (playerState == PlayerState.idle || playerState == PlayerState.death) 
        {
            return;
        }

        if (playerState == PlayerState.running) 
        {
            directionChange = inputActions.PlayerMovement.Movement.ReadValue<Vector3>();
        }

        if (IsOnGround() && inputActions.PlayerMovement.JumpMovement.WasPressedThisFrame()) 
        {
            EnableJump();
        }

        if (inputActions.PlayerMovement.SwordAttack.WasPressedThisFrame()) 
        {
            EnableSwordAttack();
        }

        if (inputActions.PlayerMovement.EnableSuper.WasPressedThisFrame()) 
        {
            superIsPressed = true;
        }
    }

    #region Movement Methods
    //Enable Checking States to divide between Update and Fixed Update
    private void CheckMovement() 
    {
        if (playerState == PlayerState.running) 
        {
            UpdateMovement();
        }
    }

    //Update the Movement through Fixed Update and Animation Procedures
    private void UpdateMovement() 
    {
        

        if (directionChange != Vector3.zero)
        {
            SetMovement();
            directionChange.x = Mathf.Round(directionChange.x);
            directionChange.y = Mathf.Round(directionChange.y);
            animator.SetFloat("moveX", directionChange.x);
            animator.SetBool("isWalking", true);
        }

        if (directionChange == Vector3.zero) 
        {
            animator.SetBool("isWalking", false);
        }
    }

    //Physics Method for Movement
    private void SetMovement() 
    {
        directionChange.Normalize();
        rigidbody.MovePosition(transform.position + directionChange * playerSpeed * Time.fixedDeltaTime);
    }
    #endregion

    #region Jump Methods
    private void EnableJump() 
    {
        rigidbody.velocity = Vector2.up * playerJump;
    }

    //Check if the player is still on the Ground or on the Tilemap
    private bool IsOnGround() 
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down * 0.1f, groundGetLayer);
        return raycastHit2D.collider != null;
    }
    #endregion

    private void EnableSwordAttack() 
    {
        directionChange.x = Mathf.Round(directionChange.x);
        directionChange.y = Mathf.Round(directionChange.y);

        animator.SetFloat("moveX", directionChange.x);
        animator.SetBool("isAttacking", true);
        StartCoroutine(DisableAttack());
    }

    private IEnumerator DisableAttack() 
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isAttacking", false);
    }

    public void CheckHealth(float deathIncrement) 
    {
        playerDeathCounter.runtimeValue += deathIncrement;
        transform.position = playerPosition.startingPosition;
    }
}
