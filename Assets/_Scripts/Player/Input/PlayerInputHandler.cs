using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public int NormalInputX { get; private set; }
    public int NormalInputY { get; private set; }
    public bool JumpInput { get; private set; }
    public bool GrabInput { get; private set; }
    public bool RollInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    [SerializeField] private float InputHoldTime = 0.2f;

    private float JumpInputStartTime;
    private float RollInputStartTime;

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckRollInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormalInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormalInputY = Mathf.RoundToInt(RawMovementInput.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStartTime = Time.time;
            JumpInputStop = false;
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GrabInput = true;
        }

        if (context.canceled)
        {
            GrabInput = false;
        }
    }

    public void OnRollInput(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            RollInput = true;
            RollInputStartTime = Time.time;
        }
    }

    public void UseJumpInput() => JumpInput = false;
    public void UseRollInput() => RollInput = false;

    private void CheckJumpInputHoldTime()
    {
        if(Time.time >= JumpInputStartTime + InputHoldTime)
        {
            JumpInput = false;
        }
    }

    private void CheckRollInputHoldTime()
    {
        if(Time.time >= RollInputStartTime + InputHoldTime)
        {
            RollInput = false;
        }
    }

}
