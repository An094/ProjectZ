using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput {  get; private set; }
    public int NormalInputX {  get; private set; }
    public int NormalInputY {  get; private set; }
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    [SerializeField] private float InputHoldTime = 0.2f;

    private float JumpInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormalInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        NormalInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStartTime = Time.time;
            JumpInputStop = false;
        }

        if(context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void UseJumpInput() => JumpInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= JumpInputStartTime + InputHoldTime)
        {
            JumpInput = false;
        }
    }
}
