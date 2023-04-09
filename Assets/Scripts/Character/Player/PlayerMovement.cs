using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    [SerializeField]
    UmbrellaController umbrella;
    [SerializeField]
    float minGlideHeight = 5.0f;
    [SerializeField]
    float windResistance = 1.0f;

    bool isGliding;
    
    protected override Vector3 CalculateVerticalMovement() 
    {
        if (!isGliding && CanGlide())
        {
            // Character is gliding.
            isGliding = true;
            isJumping = false;
            physics.GravityScale = 0.25f;
        }
        else if(physics.IsGrounded || umbrella.CurrentPose == UmbrellaPose.CLOSED)
        {
            isGliding = false;
            physics.GravityScale = 1f;
        }
        
        return base.CalculateVerticalMovement();
    }

    bool CanGlide()
    {
        // Character is falling from above minimum glide distance with their umbrella open.
        Debug.Log(physics.DistanceToGround);
        return (isFalling && physics.DistanceToGround >= minGlideHeight && umbrella.CurrentPose == UmbrellaPose.OPEN);
    }

    public bool IsGliding
    {
        get { return isGliding; }
    }

    protected override void ApplyJumpCut()
    {
        // Don't apply effects of canceling jump when gliding.
        if(!IsGliding)
        {
            base.ApplyJumpCut();
        }
    }
}
