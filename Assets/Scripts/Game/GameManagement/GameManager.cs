using UnityEngine;
// Game Service Locator
public class GameManager : MonoBehaviour, IGameManager
{
    [SerializeField]
    InputManager input;
    [SerializeField]
    CharacterController character;
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

    public CharacterController Character
    {
        get { return character; }
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