using UnityEngine;

public class InputManager : GameBehaviour
{
    private PlayerInput playerInput;
    private CharacterControls characterControls;
    private WeatherControls weatherControls;

    void Awake()
    {
        playerInput = new PlayerInput();
        characterControls = new CharacterControls(playerInput, gameManager.Player);
        weatherControls = new WeatherControls(playerInput, gameManager.Weather);
    }

    void OnEnable()
    {
        playerInput?.Enable();
        characterControls?.AssignControls();
        weatherControls?.AssignControls();
    }

    void OnDisable()
    {
        playerInput?.Disable();
        characterControls?.UnassignControls();
        weatherControls?.UnassignControls();
    }

    public PlayerInput PlayerInput
    {
        get { return playerInput; }
    }

    public CharacterControls CharacterControls
    {
        get { return characterControls; }
    }

    public WeatherControls WeatherControls
    {
        get { return weatherControls; }
    }
}