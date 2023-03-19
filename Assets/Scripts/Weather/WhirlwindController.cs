using UnityEngine;

public class WhirlwindController : GameBehaviour
{
    [SerializeField]
    GameObject whirlwindPrefab;

    CharacterController character;

    Vector3 initialPosition;

    void Start()
    {
        character = gameManager.Character;
    }

    public void Boost()
    {
        if(character.Movement.IsGrounded)
        {
            initialPosition = character.transform.position;
            Instantiate(whirlwindPrefab, initialPosition, Quaternion.identity);
            character.Context.Hover();
        }
    }

    public void Release()
    {
        character.Context.Continue();
    }
}
