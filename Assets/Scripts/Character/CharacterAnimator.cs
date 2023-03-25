using UnityEngine;

public class CharacterAnimator : GameBehaviour
{
    [SerializeField]
    CharacterController character;
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
        float speedPercent = character.Movement.Magnitude / character.Movement.MaxSpeed;
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
