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
    float smoothTime = 0.1f;

    void Update()
    {
        float speedPercent = player.Movement.Direction.magnitude * player.Movement.Speed / player.Movement.RunSpeed;
        animator.SetFloat(speedParameterName, speedPercent, smoothTime, Time.deltaTime);
    }

    public void IsHovering(bool airborne)
    {
        animator.SetBool(isHoveringParameterName, airborne);
    }

    public void IsGliding(bool gliding)
    {
        animator.SetBool(isGlidingParameterName, gliding);
    }
}
