using UnityEngine;

public class PlayerAnimator : GameBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    string speedParameterName = "speedPercent";
    [SerializeField]
    float smoothTime = 0.1f;

    PlayerMovement movement;

    void Awake()
    {
        movement = gameManager.Player.Movement;
    }

    void Update()
    {
        //float speedPercent = movement.Direction.magnitude / movement.Speed;
        float speedPercent = movement.Direction.magnitude * movement.Speed / movement.RunSpeed;
        animator.SetFloat(speedParameterName, speedPercent, smoothTime, Time.deltaTime);
    }
}
