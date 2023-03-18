using UnityEngine;

public class WhirlwindController : GameBehaviour
{
    [SerializeField]
    GameObject whirlwindPrefab;

    PlayerController player;

    public float amplitude = 0.5f;   // The height of the floating movement.
    public float speed = 1.0f;       // The speed of the floating movement.
    public float offset = 0.0f;      // The starting offset of the floating movement.
    public float floatHeight = 0.0f;      // The distance off the ground to float.

    Vector3 startPosition;
    bool isBoosted = false;

    void Awake()
    {
        player = gameManager.Player;
    }
    
    void FixedUpdate()
    {
        if(isBoosted)
        {
            // Move the character up and down using the Mathf.Sin() function to create a floating effect.
            float y = startPosition.y + amplitude * Mathf.Sin(speed * Time.time + offset);
            float height = y + floatHeight;
            Debug.Log(y + " " + floatHeight);
            Vector3 movement = new Vector3(0.0f, height - player.transform.position.y, 0.0f);
            player.Move(movement);
        }
    }

    public void Boost()
    {
        if(player.Movement.IsGrounded)
        {
            gameManager.Input.CharacterControls.UnassignControls();
            isBoosted = true;
            startPosition = player.transform.position;
            Instantiate(whirlwindPrefab, startPosition, Quaternion.identity);
            player.Movement.GravityPower = 0.0f;
            this.enabled = true;
        }
    }

    public void Release()
    {
        isBoosted = false;
        gameManager.Input.CharacterControls.AssignControls();
        player.Movement.GravityPower = 1.0f;
        player.Movement.Move(new Vector3());
        this.enabled = false;
    }
}
