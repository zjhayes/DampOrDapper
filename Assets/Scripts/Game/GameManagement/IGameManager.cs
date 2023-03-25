using UnityEngine;

public interface IGameManager : IService
{
    public InputManager Input { get; }

    public CharacterController Character { get; }

    public CameraManager Cameras { get; }

    public WeatherManager Weather { get; }
}