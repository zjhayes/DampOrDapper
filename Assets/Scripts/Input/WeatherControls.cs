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
    }

    public void UnassignControls()
    {
        // Unassign input controls from weather controller.
        input.Weather.Whirlwind.started -= _ => manager.Whirlwind.Boost();
        input.Weather.Whirlwind.canceled -= _ => manager.Whirlwind.Release();
    }
}
