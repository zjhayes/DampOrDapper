using UnityEngine;

public class WeatherManager : GameBehaviour
{
    [SerializeField]
    WhirlwindController whirlwind;

    public WhirlwindController Whirlwind
    {
        get { return whirlwind; }
    }
}
