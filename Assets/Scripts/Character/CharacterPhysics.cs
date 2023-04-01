using UnityEngine;

public class CharacterPhysics : GameBehaviour
{
    [SerializeField]
    float terminalVelocity = 53.0f;
    [SerializeField]
    float gravityValue = -9.81f;

    public const float GROUND_BUFFER = 0.1f;

    Vector3 velocity;
    float gravityScale = 1f;

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
        get { return DistanceToGround <= GROUND_BUFFER; }
    }

    public float DistanceToGround
    {
        get
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
    }

    public void ApplyVerticalForce(float force)
    {
        // Use kinematic equation for vertical displacement.
        velocity.y = Mathf.Sqrt(force * -2 * gravityValue * gravityScale);
    }

    public void ApplyHorizontalForce(float force)
    {
        velocity.x += force;
    }

    public void ApplyGravity()
    {
        Debug.Log(gravityScale);
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        else
        {
            Vector3 targetVelocity = Vector3.down * terminalVelocity * gravityScale;
            float gravityRate = Mathf.Abs(gravityValue) * gravityScale * Time.deltaTime;

            LerpVelocity(targetVelocity, gravityRate);
        }
    }

    public void LerpVelocity(Vector3 targetVelocity, float lerpAmount)
    {
        velocity = Vector3.Lerp(velocity, targetVelocity, lerpAmount);
    }
}
