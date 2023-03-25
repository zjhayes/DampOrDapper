using UnityEngine;

/** Character moves to next destination. **/
public class NavigationState : CharacterState
{
    void OnEnable()
    {
        character.Movement.enabled = true;
        character.Movement.MoveTo(character.Destination.position);
    }

    void OnDisable()
    {
        character.Movement.enabled = false;
    }
}
