using UnityEngine;

public interface ICharacterController : IController
{
    public CharacterMovement Movement { get; }
    public CharacterContext Context { get; }
    public Transform Destination { get; set; }
}
