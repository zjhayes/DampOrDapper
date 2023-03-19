using UnityEngine;

public class CharacterController : GameBehaviour, ICharacterController
{
    [SerializeField]
    CharacterMovement movement;
    [SerializeField]
    CharacterAnimator animator;
    [SerializeField]
    CharacterContext context;
    [SerializeField]
    Transform destination;

    void Start()
    {
        context.Continue();
    }

    public CharacterMovement Movement
    {
        get { return movement; }
    }

    public CharacterAnimator Animator
    {
        get { return animator; }
    }

    public CharacterContext Context
    {
        get { return context; }
    }

    public Transform Destination
    {
        get { return destination; }
        set { destination = value; }
    }
}
