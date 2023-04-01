using UnityEngine;

public class PlayerController : GameBehaviour
{
    [SerializeField]
    PlayerMovement movement;
    [SerializeField]
    UmbrellaController umbrella;
    [SerializeField]
    CharacterPhysics physics;
    [SerializeField]
    CharacterAnimator animator;

    public delegate void OnAttack();
    public event OnAttack onAttack;

    public delegate void OnShield();
    public event OnShield onShield;

    void OnEnable()
    {
        
    }

    void OnDisable()
    {

    }

    public void Attack()
    {
        movement.Walk();
        umbrella.CurrentPose = UmbrellaPose.CLOSED;
        onAttack?.Invoke();
    }

    public void Shield(bool enable)
    {
        if (enable)
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

    public CharacterPhysics Physics
    {
        get { return physics; }
    }
}
