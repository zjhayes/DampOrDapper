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
        // Calculate player speed percent to blend between animations.
        float speedPercent = player.Movement.Direction.magnitude * player.Movement.Speed / player.Movement.RunSpeed;
        animator.SetFloat(speedParameterName, speedPercent, smoothTime, Time.deltaTime);

        IsGliding(player.Movement.IsGliding);
        IsJumping(player.Movement.IsJumping);
        animator.SetBool("isGrounded", player.Physics.IsGrounded);
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
