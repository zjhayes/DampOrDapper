using UnityEngine;

public class AirborneState : CharacterState
{
    void OnEnable()
    {
        character.Movement.RigidBody.isKinematic = false;
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
    }
}
