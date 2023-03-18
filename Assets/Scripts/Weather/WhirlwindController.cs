using UnityEngine;

public class WhirlwindController : GameBehaviour
{
    [SerializeField]
    GameObject whirlwindPrefab;

    CharacterController character;

    public float amplitude = 0.5f;   // The height of the floating movement.
    public float speed = 1.0f;       // The speed of the floating movement.
    public float offset = 0.0f;      // The starting offset of the floating movement.
    public float floatHeight = 0.0f;      // The distance off the ground to float.

    Vector3 startPosition;
    bool isBoosted = false;

    void Awake()
    {
        character = gameManager.Character;
    }
    
    void FixedUpdate()
    {
        if(isBoosted)
        {
            // Move the character up and down using the Mathf.Sin() function to create a floating effect.
            float y = startPosition.y + amplitude * Mathf.Sin(speed * Time.time + offset);
            float height = y + floatHeight;
            Debug.Log(y + " " + floatHeight);
            Vector3 movement = new Vector3(0.0f, height - character.transform.position.y, 0.0f);
            //character.Move(movement);
        }
    }

    public void Boost()
    {
        /*
        if(character.Movement.IsGrounded)
        {
            gameManager.Input.CharacterControls.UnassignControls();
            isBoosted = true;
            startPosition = character.transform.position;
            Instantiate(whirlwindPrefab, startPosition, Quaternion.identity);
            character.Movement.GravityPower = 0.0f;
            this.enabled = true;
        }*/
    }

    public void Release()
    {/*
        isBoosted = false;
        gameManager.Input.CharacterControls.AssignControls();
        character.Movement.GravityPower = 1.0f;
        character.Movement.Move(new Vector3());
        this.enabled = false;*/
    }
}
