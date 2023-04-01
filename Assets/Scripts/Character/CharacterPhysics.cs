using UnityEngine;

public class CharacterPhysics : GameBehaviour
{
    [SerializeField]
    float terminalVelocity = 53.0f;
    [SerializeField]
    float gravityValue = 9.81f;

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
        velocity.y += force;
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
        Vector3 targetVelocity = Vector3.down * terminalVelocity * gravityScale;
        float gravityRate = gravityValue * gravityScale;

        LerpVelocity(targetVelocity, gravityRate);
    }

    public void LerpVelocity(Vector3 targetVelocity, float lerpAmount)
    {
        lerpAmount = lerpAmount * Time.deltaTime;
        
        velocity = Vector3.Lerp(velocity, targetVelocity, lerpAmount);
    }
}
