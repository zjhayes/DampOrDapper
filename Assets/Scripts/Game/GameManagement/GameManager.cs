using UnityEngine;
// Game Service Locator
public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField]
    InputManager input;
    [SerializeField]
    PlayerController player;
    [SerializeField]
    CameraManager cameras;
    [SerializeField]
    WeatherManager weather;

    void Awake()
    {
        // Inject GameManager into GameBehaviours.
        ServiceInjector.Resolve<IGameManager, GameBehaviour>(this);
    }

    public InputManager Input
    {
        get { return input; }
    }

    public PlayerController Player
    {
        get { return player; }
    }

    public CameraManager Cameras
    {
        get { return cameras; }
    }

    public WeatherManager Weather
    {
        get { return weather; }
    }
}