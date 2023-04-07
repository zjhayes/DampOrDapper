using UnityEngine;

public class CharacterPhysics : GameBehaviour
{
    [SerializeField]
    float terminalVelocity = 53.0f;
    [SerializeField]
    float gravityValue = -9.81f;

    const float GROUND_BUFFER = 0.01f; // Distance from ground to be considered grounded.

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
    float groundBuffer = 0.1f;
    public bool IsGrounded
    {
        get { return DistanceToGround <= groundBuffer; }//GROUND_BUFFER; }
    }
    float centerOffset = .75f;//1.5f;
    public float radius = 0.7f;
    public float height = 3.0f;

    public float DistanceToGround
    {
        get
        {
            RaycastHit hit;
            float distanceBuffer = 0.1f;
            float halfHeight = height / 2.0f - radius;
            Vector3 center = transform.position + Vector3.up * centerOffset;
            //if (Physics.Raycast(transform.position, Vector3.down, out hit))
            Debug.DrawLine(center, center - Vector3.up * halfHeight, Color.green);
            if (Physics.SphereCast(center, radius, Vector3.down, out hit, halfHeight))
            {
                
                //distanceBuffer = CalculateDistanceBuffer(hit, center);
                distanceBuffer = 0.1f;
                Debug.Log(distanceBuffer + " Buffer");
                float distanceToGround = hit.distance;// + radius - halfHeight;
                Debug.Log(distanceToGround + " Distance");
                Debug.Log(distanceToGround <= distanceBuffer);
                groundBuffer = distanceBuffer;
                return hit.distance;
            }
            else
            {
                return float.MaxValue;
            }
        }
    }

    float CalculateDistanceBuffer(RaycastHit hit, Vector3 center)
    {
        float angle = Vector3.Angle(hit.normal, Vector3.up);
        float radianAngle = Mathf.Deg2Rad * angle;
        Vector3 hitPoint = hit.point;
        float halfHeight = height / 2.0f - radius;
        float distanceFromHitPointToCharacterCenter = Vector3.Distance(hitPoint, center);
        if(distanceFromHitPointToCharacterCenter < (0.1f + halfHeight))
        {
            return 0.1f;// + halfHeight;
        }
        //float distanceBuffer = (distanceFromHitPointToCharacterCenter - 0.7f) / Mathf.Cos(radianAngle) + radius;
        float distanceBuffer = radius / Mathf.Sin(radianAngle) - distanceFromHitPointToCharacterCenter * Mathf.Tan(radianAngle);
        if(distanceBuffer > 5f)
        {
            return 0.1f;// + halfHeight;
        }
        return distanceBuffer;
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
            float angle = Vector3.Angle(hit.normal, Vector3.up);
            //Debug.Log(angle);
            return true;
        }
        else
        {
            return false;
        }
    }

    void ResetVerticalVelocity()
    {
        velocity.y = 0f;
    }
}
