using UnityEngine;

public class AirborneState : CharacterState
{
    void OnEnable()
    {
        character.Movement.RigidBody.isKinematic = false;
        character.Animator.IsHovering(true); // TODO: Swap with own animation.
    }

    void Update()
    {
        if(character.Movement.IsGrounded)
        {
            character.Context.Continue();
        }
    }

    void OnDisable()
    {
        character.Movement.RigidBody.isKinematic = true;
        character.Animator.IsHovering(false);
    }
}
