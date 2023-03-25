using UnityEngine;

/** Character glides down gently. **/
public class GlideState : CharacterState
{
    [SerializeField]
    float gravityScale = 0.5f;
    [SerializeField]
    float windScale = 2.0f;
    /*
    void OnEnable()
    {
        character.Movement.RigidBody.isKinematic = false;
        character.Animator.IsGliding(true);
    }

    void FixedUpdate()
    {
        if (character.Movement.IsGrounded)
        {
            character.Context.Continue();
        }
        else
        {
            // Apply gravity and account for wind.
            Vector3 movement = Physics.gravity * gravityScale;
            movement.x += gameManager.Weather.WindVelocity * windScale;
            character.Movement.RigidBody.AddForce(movement, ForceMode.Acceleration);
        }
    }

    void OnDisable()
    {
        character.Movement.RigidBody.isKinematic = true;
        character.Animator.IsGliding(false);
    }*/
}
