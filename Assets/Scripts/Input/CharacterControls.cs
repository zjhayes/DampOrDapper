using UnityEngine;

public class CharacterControls
{
    PlayerInput input;
    PlayerController controller;

    public CharacterControls(PlayerInput input, PlayerController controller)
    {
        this.input = input;
        this.controller = controller;
    }

    public void AssignControls()
    {
        // Assign input controls to character controller.
        input.Character.Movement.performed += ctx => controller.Movement.Move(ctx.ReadValue<Vector2>());
        input.Character.Run.started += _ => controller.Movement.Run();
        input.Character.Run.canceled += _ => controller.Movement.Walk();
        input.Character.Jump.started += _ => controller.Movement.Jump();
        input.Character.Attack.performed += _ => controller.Attack();
        input.Character.Shield.started += _ => controller.Shield(true);
        input.Character.Shield.canceled += _ => controller.Shield(false);
    }

    public void UnassignControls()
    {
        // Unassign input controls from character controller.
        input.Character.Movement.performed -= ctx => controller.Movement.Move(ctx.ReadValue<Vector2>());
        input.Character.Run.started -= _ => controller.Movement.Run();
        input.Character.Run.canceled -= _ => controller.Movement.Walk();
        input.Character.Jump.started -= _ => controller.Movement.Jump();
        input.Character.Attack.performed -= _ => controller.Attack();
        input.Character.Shield.started -= _ => controller.Shield(true);
        input.Character.Shield.canceled -= _ => controller.Shield(false);
    }
}