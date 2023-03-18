using UnityEngine;

public interface IGameManager : IService
{
    public InputManager Input { get; }

    public PlayerController Player { get; }

    public CameraManager Cameras { get; }

    public WeatherManager Weather { get; }
}