using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(CharacterPhysics))]
public class PlayerController : GameBehaviour
{
    [SerializeField]
    UmbrellaController umbrella;
    [SerializeField]
    CharacterAnimator animator;

    PlayerMovement movement;
    CharacterPhysics physics;

    public delegate void OnAttack();
    public event OnAttack onAttack;

    public delegate void OnShield();
    public event OnShield onShield;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        physics = GetComponent<CharacterPhysics>();
    }

    public void Attack()
    {
        //movement.Walk();
        umbrella.CurrentPose = UmbrellaPose.CLOSED;
        onAttack?.Invoke();
    }

    public void Shield(bool enable)
    {
        if (enable)
        {
            //movement.Walk();
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
