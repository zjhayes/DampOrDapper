using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : GameBehaviour
{
    [SerializeField]
    float walkSpeed = 2.0f;
    [SerializeField]
    float runSpeed = 6.0f;
    [SerializeField]
    float gravityValue = 9.81f;
    [SerializeField]
    float gravityPower = 1f;

    PlayerController player;
    CharacterController controller;
    float gravity;
    Vector3 direction;
    Vector3 velocity;
    float moveSpeed;
    bool isRunning;
    bool isGrounded;

    void Awake()
    {
        player = gameManager.Player;
        controller = GetComponent<CharacterController>();
        gravity = gravityValue;
    }
    
    void FixedUpdate()
    {
        // Determine if player is grounded.
        CheckForGround();

        // Move character.
        Vector3 horizontalMovement = CalculateHorizontalMovement();
        controller.Move(horizontalMovement);

        // Turn character to face the direction they're moving.
        if (isGrounded && horizontalMovement != Vector3.zero)
        {
            FaceDirection(horizontalMovement);
        }

        // Change the vertical position of the player.
        Vector3 verticalMovement = CalculateVerticalMovement();
        controller.Move(verticalMovement);
    }

    void CheckForGround()
    {
        isGrounded = controller.isGrounded;
        // Ensure player remains above ground.
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }

    Vector3 CalculateHorizontalMovement()
    {
        Vector3 move = new Vector3(direction.x, 0f, 0f);
        move.Normalize();
        return move * Time.deltaTime * moveSpeed;
    }

    Vector3 CalculateVerticalMovement()
    {
        // Apply gravity.
        velocity.y -= gravity * gravityPower * Time.deltaTime;
        Vector3 verticalMove = new Vector3(0f, velocity.y + direction.y, 0f);
        return verticalMove * Time.deltaTime;
        
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
        this.direction = new Vector3(direction.x, direction.y, 0f);
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
        get { return isGrounded; }
    }

    public float GravityPower
    {
        get { return gravity; }
        set { gravity = value; }
    }
}
