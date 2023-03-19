using UnityEngine;

public class CharacterState : GameBehaviour, ICharacterState
{
    protected ICharacterController character;

    public virtual void Handle(ICharacterController controller)
    {
        character = controller;
        this.enabled = true;
    }

    public virtual void Destroy()
    {
        this.enabled = false;
    }
}
