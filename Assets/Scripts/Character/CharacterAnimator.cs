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
    float smoothTime = 0.1f;

    void Update()
    {
        float speedPercent = character.Movement.Magnitude / character.Movement.MaxSpeed;
        animator.SetFloat(speedParameterName, speedPercent, smoothTime, Time.deltaTime);
    }
}
