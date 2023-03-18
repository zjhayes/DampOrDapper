using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    CharacterMovement movement;
    [SerializeField]
    Transform destination;

    void Awake()
    {
        Debug.Log(movement);
    }

    void Start()
    {
        movement.MoveTo(destination.position);
    }

    public CharacterMovement Movement
    {
        get { return movement; }
    }
}
