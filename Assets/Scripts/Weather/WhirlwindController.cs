using UnityEngine;

public class WhirlwindController : GameBehaviour
{
    [SerializeField]
    float launchSpeed = 15.0f;
    [SerializeField]
    GameObject whirlwindPrefab;

    CharacterController character;

    Vector3 initialPosition;

    bool isLaunched;

    void Start()
    {
        character = gameManager.Character;
        isLaunched = false;
    }

    void Update() // TODO: Replace Update method
    {
        if(character.Movement.IsGrounded)
        {
            isLaunched = false;
        }
    }

    public void Boost()
    {
        if(character.Movement.IsGrounded)
        {
            initialPosition = character.transform.position;
            Instantiate(whirlwindPrefab, initialPosition, Quaternion.identity);
            character.Context.Hover();
        }
        else
        {
            // Launch character.
            if(!isLaunched)
            {
                Vector3 launchVelocity = new Vector3(0f, launchSpeed, 0f);
                character.Movement.RigidBody.velocity = character.Movement.RigidBody.velocity + launchVelocity;
                isLaunched = true;
            }
        }
    }

    public void Release()
    {
        if(!isLaunched)
        {
            character.Context.Continue();
        }
    }
}
