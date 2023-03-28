using UnityEngine;

public class CharacterAnimator : GameBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    Animator animator;
    [SerializeField]
    string speedParameterName = "speedPercent";
    [SerializeField]
    string isHoveringParameterName = "isHovering";
    [SerializeField]
    string isGlidingParameterName = "isGliding";
    [SerializeField]
    string isJumpingParameterName = "isJumping";
    [SerializeField]
    float smoothTime = 0.1f;

    void Update()
    {
        float speedPercent = player.Movement.Direction.magnitude * player.Movement.Speed / player.Movement.RunSpeed;
        animator.SetFloat(speedParameterName, speedPercent, smoothTime, Time.deltaTime);

        if (player.Movement.IsGrounded == false)
        {
            if (player.Movement.Velocity.y > 0)
            {
                IsJumping(true);
            }
            else if (player.Movement.Velocity.y < 0)
            {
                IsGliding(true);
                IsJumping(false);
            }
            else
            {
                IsHovering(true);
            }
        }
        else
        {
            IsJumping(false);
            IsGliding(false);
            IsHovering(false);
        }
    }

    public void IsHovering(bool airborne)
    {
        animator.SetBool(isHoveringParameterName, airborne);
    }

    public void IsGliding(bool gliding)
    {
        animator.SetBool(isGlidingParameterName, gliding);
    }

    public void IsJumping(bool jumping)
    {
        animator.SetBool(isJumpingParameterName, jumping);
    }
}
