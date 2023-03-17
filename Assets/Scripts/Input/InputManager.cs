using UnityEngine;

public class InputManager : GameBehaviour
{
    private PlayerInput playerInput;
    private CharacterControls characterControls;

    void Awake()
    {
        playerInput = new PlayerInput();
        characterControls = new CharacterControls(playerInput, gameManager.Player);
    }

    void OnEnable()
    {
        playerInput?.Enable();
        characterControls?.AssignControls();
    }

    void OnDisable()
    {
        playerInput?.Disable();
        characterControls?.UnassignControls();
    }

    public PlayerInput PlayerInput
    {
        get { return playerInput; }
    }

    public CharacterControls CharacterControls
    {
        get { return characterControls; }
    }

    /* TODO: menu controls etc... */
}