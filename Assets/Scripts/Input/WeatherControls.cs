using UnityEngine;

public class WeatherControls
{
    PlayerInput input;
    WeatherManager manager;

    public WeatherControls(PlayerInput input, WeatherManager manager)
    {
        this.input = input;
        this.manager = manager;
    }

    public void AssignControls()
    {
        // Assign input controls to weather controller.
        input.Weather.Whirlwind.started += _ => manager.Whirlwind.Boost();
        input.Weather.Whirlwind.canceled += _ => manager.Whirlwind.Release();
        input.Weather.RainIntensity.performed += ctx => IncrementRainIntensity(ctx.ReadValue<float>());
        input.Weather.WindVelocity.performed += ctx => IncrementWindVelocity(ctx.ReadValue<float>());
    }

    void IncrementRainIntensity(float increment)
    {
        manager.RainIntensity += increment;
    }

    void IncrementWindVelocity(float increment)
    {
        manager.WindVelocity += increment;
    }

    public void UnassignControls()
    {
        // Unassign input controls from weather controller.
        input.Weather.Whirlwind.started -= _ => manager.Whirlwind.Boost();
        input.Weather.Whirlwind.canceled -= _ => manager.Whirlwind.Release();
    }
}
