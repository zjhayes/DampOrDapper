using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterPhysics))]
public class CharacterMovement : GameBehaviour, ICharacterMovement
{
    [SerializeField]
    float walkSpeed = 3.0f;
    [SerializeField]
    float runSpeed = 6.0f;
    [SerializeField]
    float jumpPower = 3.0f;
    [SerializeField]
    float coyoteTime = 0.2f;
    [SerializeField]
    float jumpInputTolerance = 0.2f;
    [SerializeField]
    float forwardSlipSpeed = 1f; // Speed at which character slips on to edges.
    [SerializeField]
    float backwardSlipSpeed = 3f; // Speed at which character slips off of edges.
    [SerializeField]
    float edgeCheckHeight = -0.1f; // Check should be below character controller.
    [SerializeField]
    float jumpCutGravityScale = 1.5f;

    public delegate void OnRun();
    public event OnRun onRun;

    public delegate void OnWalk();
    public event OnWalk onWalk;

    public delegate void OnJump();
    public event OnJump onJump;

    const float FALL_BUFFER = -0.1f; // Minimum speed to be considered falling.

    CharacterController controller;
    protected CharacterPhysics physics;
    Vector3 direction;
    float moveSpeed;
    bool isRunning;
    protected bool isJumping;
    protected bool jumpCanceled;
    protected bool isFalling;

    float timeSinceJumpInput;
    protected float timeSinceGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        physics = GetComponent<CharacterPhysics>();
    }

    void LateUpdate()
    {
        // Update action timers.
        timeSinceJumpInput -= Time.deltaTime;

        GroundCheck();
        ApplySlip();

        // Move character.
        Vector3 horizontalMovement = CalculateHorizontalMovement();
        controller.Move(horizontalMovement);

        // Turn character to face the direction they're moving.
        if (horizontalMovement != Vector3.zero)
        {
            FaceDirection(horizontalMovement);
        }

        // Change the vertical position of the player.
        Vector3 verticalMovement = CalculateVerticalMovement();

        controller.Move(verticalMovement);
    }

    protected virtual Vector3 CalculateHorizontalMovement()
    {
        Vector3 move = new Vector3(direction.x, 0f, 0f);
        move.Normalize();
        return direction * Time.deltaTime * moveSpeed;
    }

    protected virtual Vector3 CalculateVerticalMovement()
    {
        ApplyJumpCut();

        physics.ApplyGravity();

        JumpWhenReady();

        return physics.Velocity * Time.deltaTime;
    }

    void FaceDirection(Vector3 directionToFace)
    {
        gameObject.transform.forward = directionToFace;
    }

    void GroundCheck()
    {
        if (physics.IsGrounded)
        {
            // Set timer to coyote time to allow for late jumps from edge of ground.
            timeSinceGrounded = coyoteTime;
            isJumping = false;
            jumpCanceled = false;
            isFalling = false;
        }
        else // not grounded.
        {
            timeSinceGrounded -= Time.deltaTime;

            // When coyote time is expired...
            if(timeSinceGrounded <= 0)
            {
                // Check if character is moving down.
                isFalling = physics.Velocity.y < FALL_BUFFER;
            }
        }
    }

    void JumpWhenReady()
    {
        // Jump when ready and able.
        if (timeSinceGrounded >= 0 && timeSinceJumpInput >= 0)
        {
            // Jump.
            isJumping = true;
            physics.ApplyVerticalForce(jumpPower);
            timeSinceJumpInput = -1f; // Unready jump.
            onJump?.Invoke();
        }
    }

    // Prevents character from getting stuck on edges.
    void ApplySlip()
    {
        RaycastHit hit;
        if (physics.PathObstructed(transform.forward, edgeCheckHeight, controller.radius))
        {
            // Character is facing edge.
            controller.Move(Slip(forwardSlipSpeed));
        }
        else if(physics.PathObstructed(-transform.forward, edgeCheckHeight, controller.radius))
        {
            // Character is facing away from edge.
            controller.Move(Slip(backwardSlipSpeed));
        } // else character is not on edge.
    }

    protected virtual void ApplyJumpCut()
    {
        // Add gravity if jump canceled.
        if (isJumping && jumpCanceled)
        {
            physics.GravityScale = jumpCutGravityScale;
        }
    }

    void OnEnable()
    {
        Walk();
    }

    public void Move(Vector2 direction)
    {
        this.direction = new Vector3(direction.x, 0f, 0f);
    }
    
    public void Run()
    {
        // Toggle run speed.
        moveSpeed = runSpeed;
        isRunning = true;
        onRun?.Invoke();
    }

    public void Walk()
    {
        // Toggle walk speed.
        moveSpeed = walkSpeed;
        isRunning = false;
        onWalk?.Invoke();
    }

    public void Jump()
    {
        // Ready jump.
        timeSinceJumpInput = jumpInputTolerance;
    }

    public void JumpCut()
    {
        jumpCanceled = true;
    }

    // Slide character forward.
    public Vector3 Slip(float slipSpeed)
    {
        return ((transform.forward * slipSpeed) + Vector3.up) * Time.deltaTime;
    }

    public Vector3 Direction
    {
        get { return direction; }
    }

    public float Speed
    {
        get { return moveSpeed; }
    }

    public float RunSpeed
    {
        get { return runSpeed; }
    }

    public bool IsMoving
    {
        get { return direction != Vector3.zero; }
    }

    public bool IsRunning
    {
        get { return isRunning; }
    }

    public bool IsJumping
    {
        get { return isJumping; }
    }

    public bool IsFalling
    {
        get { return isFalling; }
    }
}
