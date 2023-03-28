using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 2.0f;
    [SerializeField]
    float runSpeed = 6.0f;
    [SerializeField]
    float jumpPower = 5f;
    [SerializeField]
    float gravityValue = -9.81f;
    [SerializeField]
    float jumpInputTolerance = 0.3f;
    [SerializeField]
    float minGlideHeight = 5.0f;
    [SerializeField]
    float windResistance = 1.0f;

    const float GROUND_BUFFER = 0.1f;

    CharacterController controller;
    Vector3 direction;
    Vector3 velocity;
    float moveSpeed;
    bool isRunning;
    float gravityScale = 1f;

    float timeSinceJumpPressed;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        timeSinceJumpPressed -= Time.deltaTime;

        // Determine if player is grounded.
        CheckGround();

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

    void CheckGround()
    {
        if (controller.isGrounded)
        {
            // Ensure player remains above ground.
            if (velocity.y < 0)
            {
                velocity.y = 0f;
            }
        }
        else // Not grounded.
        {
            //if(velocity.y < 0 && 
        }
    }

    Vector3 CalculateHorizontalMovement()
    {
        Vector3 move = new Vector3(direction.x, 0f, 0f);
        move.Normalize();
        return direction * Time.deltaTime * moveSpeed;
    }

    Vector3 CalculateVerticalMovement()
    {
        float gravityModifier = gravityScale;
        
        // Apply gravity.
        velocity.y += gravityValue * gravityScale * Time.deltaTime;

        if (IsGrounded && timeSinceJumpPressed >= 0)
        {
            // Jump.
            velocity.y += jumpPower;
        }

        return velocity * Time.deltaTime;
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
    }

    public void Walk()
    {
        moveSpeed = walkSpeed;
        isRunning = false;
    }

    public void Jump()
    {
        // Ready jump.
        timeSinceJumpPressed = jumpInputTolerance;
    }

    public Vector3 Direction
    {
        get { return direction; }
    }

    public Vector3 Velocity
    {
        get { return velocity; }
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
        get { return velocity != Vector3.zero; }
    }

    public bool IsRunning
    {
        get { return isRunning; }
    }

    public bool IsGrounded
    {
        get { return DistanceToGround() <= GROUND_BUFFER; }
    }

    public float DistanceToGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            return hit.distance;
        }
        else
        {
            return float.MaxValue;
        }
    }

    public float GravityScale
    {
        get { return gravityScale; }
        set { gravityScale = value; }
    }
}
