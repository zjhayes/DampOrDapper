using UnityEngine;

public class CharacterContext : GameBehaviour
{
    [SerializeField]
    CharacterController character;
    [SerializeField]
    NavigationState navigationState;
    [SerializeField]
    AirborneState airborneState;
    [SerializeField]
    HoverState hoverState;

    StateContext<ICharacterController> stateContext;

    void Awake()
    {
        stateContext = new StateContext<ICharacterController>(character);
    }

    public void Continue()
    {
        if(character.Movement.IsGrounded)
        {
            stateContext.Transition<NavigationState>(navigationState);
        }
        else
        {
            stateContext.Transition<AirborneState>(airborneState);
        }
    }

    public void Hover()
    {
        stateContext.Transition<HoverState>(hoverState);
    }

    public CharacterState State
    {
        get { return stateContext.CurrentState as CharacterState; }
    }
}
