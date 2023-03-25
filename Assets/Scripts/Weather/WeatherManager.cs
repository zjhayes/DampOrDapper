using UnityEngine;

public class WeatherManager : GameBehaviour
{
    [SerializeField]
    float maxRainIntensity = 3.0f;
    [SerializeField]
    float maxWindVelocity = 3.0f;
    [SerializeField]
    WhirlwindController whirlwind;

    float rainIntensity = 1.0f;
    float windVelocity = 1.0f;

    public delegate void OnRainIntensityUpdated(float rainIntensity);
    public event OnRainIntensityUpdated onRainIntensityUpdated;

    public delegate float OnWindVelocityUpdated(float windVelocity);
    public event OnWindVelocityUpdated onWindVelocityUpdated;

    public float RainIntensity
    {
        get { return rainIntensity; }
        set 
        {
            // Clamp between 0 and maximum rain intensity.
            rainIntensity = Mathf.Clamp(value, 0, maxRainIntensity);
            onRainIntensityUpdated?.Invoke(rainIntensity);
        }
    }

    public float WindVelocity
    {
        get { return windVelocity; }
        set 
        {
            // Clamp between positive and negative maximum wind velocity.
            windVelocity = Mathf.Clamp(value, -Mathf.Abs(maxWindVelocity), maxWindVelocity);
            onWindVelocityUpdated?.Invoke(windVelocity);
        }
    }

    public WhirlwindController Whirlwind
    {
        get { return whirlwind; }
    }
}
