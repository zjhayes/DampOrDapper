using UnityEngine;

public class CharacterContext : GameBehaviour
{
    [SerializeField]
    ICharacterController character;
    [SerializeField]
    NavigationState navigationState;
    [SerializeField]
    AirborneState airborneState;
    [SerializeField]
    HoverState hoverState;
    [SerializeField]
    GlideState glideState;

    StateContext<ICharacterController> stateContext;

    void Awake()
    {
        stateContext = new StateContext<ICharacterController>(character);
    }

    public void Continue()
    {/*
        if(character.Movement.IsGrounded)
        {
            Navigate();
        }
        else
        {
            stateContext.Transition<AirborneState>(airborneState);
        }*/
    }

    public void Navigate()
    {
        stateContext.Transition<NavigationState>(navigationState);
    }

    public void Hover()
    {
        stateContext.Transition<HoverState>(hoverState);
    }

    public void Glide()
    {
        stateContext.Transition<GlideState>(glideState);
    }

    public CharacterState State
    {
        get { return stateContext.CurrentState as CharacterState; }
    }
}
