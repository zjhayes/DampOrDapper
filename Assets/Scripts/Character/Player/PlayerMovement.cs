using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    [SerializeField]
    UmbrellaController umbrella;
    [SerializeField]
    float minGlideHeight = 5.0f;
    [SerializeField]
    float windResistance = 1.0f;

    bool isFalling;
    bool isGliding;

    const float FALL_BUFFER = -0.1f;

    public bool IsGliding
    {
        get { return isGliding; }
    }

    public bool IsFalling
    {
        get { return isFalling; }
    }
    
    protected override Vector3 CalculateVerticalMovement() 
    {
        // Check if character is moving down.
        isFalling = (!physics.IsGrounded && physics.Velocity.y < FALL_BUFFER);
        
        if (CanGlide())
        {
            isGliding = true;
            physics.GravityScale = 0.25f;
        }
        else if(timeSinceGrounded > 0)
        {
            isGliding = false;
            physics.GravityScale = 1f;
        }
        
        return base.CalculateVerticalMovement();
    }

    bool CanGlide()
    {
        // Character is falling from above minimum glide distance with their umbrella open.
        return (isFalling && physics.DistanceToGround >= minGlideHeight && umbrella.CurrentPose == UmbrellaPose.OPEN);
    }

}