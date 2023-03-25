using UnityEngine;

public interface ICharacterController : IController
{
    public void Move(Vector2 direction);

    public void Run();

    public void Walk();

    public void Attack();

    public void Shield(bool enable);

    public CharacterMovement Movement { get; }
}
