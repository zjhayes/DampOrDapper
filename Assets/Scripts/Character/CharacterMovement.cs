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
    float coyoteTime = 0.3f;
    [SerializeField]
    float jumpInputTolerance = 0.3f;

    public delegate void OnRun();
    public event OnRun onRun;

    public delegate void OnWalk();
    public event OnWalk onWalk;

    public delegate void OnJump();
    public event OnJump onJump;

    CharacterController controller;
    protected CharacterPhysics physics;
    Vector3 direction;
    float moveSpeed;
    bool isRunning;

    float timeSinceJumpInput;
    protected float timeSinceGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        physics = GetComponent<CharacterPhysics>();
    }

    void LateUpdate()
    {
        StayAboveGround();
        // Update action timers.
        timeSinceJumpInput -= Time.deltaTime;
        //Debug.Log(physics.Velocity);
        if(physics.IsGrounded)
        {
            // Set timer to coyote time to allow for late jumps from edge of ground.
            timeSinceGrounded = coyoteTime;
        }
        else
        {
            timeSinceGrounded -= Time.deltaTime;
        }

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
        //physics.ApplyGravity();
        //Debug.Log(physics.Velocity);
        if (timeSinceGrounded >= 0 && timeSinceJumpInput >= 0)
        {
            // Jump.
            physics.ApplyVerticalForce(jumpPower);
            //timeSinceJumpInput = 0f;
            onJump?.Invoke();
        }
        else if(!physics.IsGrounded)
        {
            //physics.SetVerticalVelocity(0f);
            physics.ApplyGravity();
        }
        
        return physics.Velocity * Time.deltaTime;
    }

    void FaceDirection(Vector3 directionToFace)
    {
        gameObject.transform.forward = directionToFace;
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
        moveSpeed = runSpeed;
        isRunning = true;
        onRun?.Invoke();
    }

    public void Walk()
    {
        moveSpeed = walkSpeed;
        isRunning = false;
        onWalk?.Invoke();
    }

    public void Jump()
    {
        // Ready jump.
        timeSinceJumpInput = jumpInputTolerance;
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

    void StayAboveGround()
    {
        if (physics.IsGrounded && physics.Velocity.y < 0)
        {
            physics.SetVerticalVelocity(0f);
        }
    }
    /*
    public bool GroundedThisFrame
    {
        get { return controller.isGrounded; }
    }
    
    void StayAboveGround()
    {
        if (GroundedThisFrame && physics.Velocity.y < 0)
        {
            physics.SetVerticalVelocity(0f);
        }
    }*/
}
