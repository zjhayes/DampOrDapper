using UnityEngine;

public class AirborneState : CharacterState
{
    [SerializeField]
    float gravityScale = 1.0f;
    [SerializeField]
    float minGlideHeight = 5.0f;
    [SerializeField]
    float windScale = 1.0f;

    void OnEnable()
    {
        character.Movement.RigidBody.isKinematic = false;
        character.Animator.IsHovering(true); // TODO: Swap with own animation.
    }

    void FixedUpdate()
    {
        if(character.Movement.IsGrounded)
        {
            character.Context.Continue();
        }
        else
        {
            float yVelocity = character.Movement.RigidBody.velocity.y;

            // If character is falling and distant from ground, glide.
            if(yVelocity < 0 && character.Movement.DistanceToGround() > minGlideHeight)
            {
                character.Context.Glide();
            }

            // Apply gravity and account for wind.
            Vector3 movement = Physics.gravity * gravityScale;
            movement.x += gameManager.Weather.WindVelocity * windScale;
            character.Movement.RigidBody.AddForce(movement, ForceMode.Acceleration);
        }
    }

    void OnDisable()
    {
        character.Movement.RigidBody.isKinematic = true;
        character.Animator.IsHovering(false);
    }
}
