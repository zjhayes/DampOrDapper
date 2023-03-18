using UnityEngine;

public class InputManager : GameBehaviour
{
    private PlayerInput playerInput;
    private WeatherControls weatherControls;

    void Awake()
    {
        playerInput = new PlayerInput();
        weatherControls = new WeatherControls(playerInput, gameManager.Weather);
    }

    void OnEnable()
    {
        playerInput?.Enable();
        weatherControls?.AssignControls();
    }

    void OnDisable()
    {
        playerInput?.Disable();
        weatherControls?.UnassignControls();
    }

    public PlayerInput PlayerInput
    {
        get { return playerInput; }
    }

    public WeatherControls WeatherControls
    {
        get { return weatherControls; }
    }

    /* TODO: menu controls etc... */
}