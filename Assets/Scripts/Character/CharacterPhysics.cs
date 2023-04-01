using UnityEngine;

public class CharacterPhysics : GameBehaviour
{
    [SerializeField]
    float terminalVelocity = 53.0f;
    [SerializeField]
    float gravityValue = -9.81f;

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
}
