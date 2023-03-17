using UnityEngine;

public class PlayerController : GameBehaviour
{
    [SerializeField]
    PlayerMovement movement;
    [SerializeField]
    UmbrellaController umbrella;

    public delegate void OnMove(Vector2 movement);
    public event OnMove onMove;

    public delegate void OnRun();
    public event OnRun onRun;

    public delegate void OnWalk();
    public event OnWalk onWalk;

    public delegate void OnAttack();
    public event OnAttack onAttack;

    public delegate void OnShield();
    public event OnShield onShield;

    public void Move(Vector2 direction)
    {
        movement.Move(direction);
        onMove?.Invoke(direction);
    }

    public void Run()
    {
        movement.Run();
        onRun?.Invoke();
    }

    public void Walk()
    {
        movement.Walk();
        onWalk?.Invoke();
    }

    public void Attack()
    {
        movement.Walk();
        umbrella.CurrentPose = UmbrellaPose.CLOSED;
        onAttack?.Invoke();
    }

    public void Shield(bool enable)
    {
        if(enable)
        {
            movement.Walk();
            umbrella.CurrentPose = UmbrellaPose.OPEN;
            onShield?.Invoke();
        }
    }

    public PlayerMovement Movement
    {
        get { return movement; }
    }

    public UmbrellaController Umbrella
    {
        get { return umbrella; }
    }
}