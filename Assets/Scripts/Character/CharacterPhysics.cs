using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterPhysics : GameBehaviour
{
    [SerializeField]
    float terminalVelocity = 53.0f;
    [SerializeField]
    float gravityValue = -9.81f;
    [SerializeField]
    float groundCheckHeight = .75f;

    const float GROUND_BUFFER = 0.1f; // Distance from ground to be considered grounded.

    CharacterController controller;
    Vector3 velocity;

    float gravityScale = 1f;
    float distanceToGround;
    bool isGrounded;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        distanceToGround = CheckGroundDistance();
        isGrounded = distanceToGround <= GROUND_BUFFER;
    }

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public float GravityValue
    {
        get { return gravityValue; }
        set { gravityValue = value; }
    }

    public float GravityScale
    {
        get { return gravityScale; }
        set { gravityScale = value; }
    }

    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    public float DistanceToGround
    {
        get { return distanceToGround; }
    }

    public void ApplyVerticalForce(float force)
    {
        // Use kinematic equation for vertical displacement.
        velocity.y += Mathf.Sqrt(force * -2 * gravityValue * gravityScale);
    }

    public void ApplyHorizontalForce(float force)
    {
        velocity.x += force;
    }

    public void SetVerticalVelocity(float yVelocity)
    {
        velocity.y = yVelocity;
    }

    public void ApplyGravity()
    {
        if (IsGrounded && velocity.y < 0)
        {
            // Prevent momentum when grounded.
            ResetVerticalVelocity();
        }

        velocity.y += gravityValue * gravityScale * Time.deltaTime;
        ClampVelocity(terminalVelocity);
    }

    public void ClampVelocity(float maxMagnitude)
    {
        velocity = Vector3.ClampMagnitude(velocity, maxMagnitude);
    }

    public void LerpVelocity(Vector3 targetVelocity, float lerpAmount)
    {
        velocity = Vector3.Lerp(velocity, targetVelocity, lerpAmount);
    }

    
    // Cast ray from character position.
    public bool PathObstructed(Vector3 direction, float height, float distance)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position + (height * Vector3.up), direction, out hit, distance))
        {
            float obstructionAngle = Vector3.Angle(hit.normal, Vector3.up);
            if(obstructionAngle > controller.slopeLimit)
            {
                return true;
            }
        }
        // If no obstruction, return false.
        return false;
    }

    float CheckGroundDistance()
    {
        RaycastHit hit;
        Vector3 center = transform.position + Vector3.up * groundCheckHeight;
        // Cast sphere beneath character.
        if (Physics.SphereCast(center, controller.radius, Vector3.down, out hit))
        {
            float groundAngle = Vector3.Angle(hit.normal, Vector3.up);
            // Only consider ground if ground angle is within slope limit.
            if (groundAngle <= controller.slopeLimit)
            {
                return hit.distance;
            }
        }

        // If no ground detected, return infinity.
        return float.MaxValue;
    }

    void ResetVerticalVelocity()
    {
        velocity.y = 0f;
    }
}
