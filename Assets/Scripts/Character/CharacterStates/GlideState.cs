using UnityEngine;

/** Character glides down gently. **/
public class GlideState : CharacterState
{
    [SerializeField]
    float gravityScale = 0.5f;

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
            // Apply gravity.
            Vector3 gravity = Physics.gravity * gravityScale;
            character.Movement.RigidBody.AddForce(gravity, ForceMode.Acceleration);
        }
    }

    void OnDisable()
    {
        character.Movement.RigidBody.isKinematic = true;
        character.Animator.IsGliding(false);
    }
}
