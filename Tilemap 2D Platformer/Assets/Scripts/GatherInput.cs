using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
    private Controls myControls;

    public float valueX;

    public bool jumpInput;

    private void Awake()
    {
        myControls = new Controls();
    }

    private void OnEnable()
    {
        myControls.Player.Move.performed += StartMove;
        myControls.Player.Move.canceled += StopMove;

        myControls.Player.Jump.performed += StartJump;
        myControls.Player.Jump.canceled += StopJump;

        myControls.Player.Enable();
    }

    private void OnDisable()
    {
        myControls.Player.Move.performed -= StartMove;
        myControls.Player.Move.canceled -= StopMove;

        myControls.Player.Jump.performed -= StartJump;
        myControls.Player.Jump.canceled -= StopJump;

        myControls.Player.Disable();

        //Can also disable everything with myControls.Disable();
    }

    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
        Debug.Log("Trying to move");
    }

    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }

    private void StartJump(InputAction.CallbackContext ctx)
    {
        jumpInput = true;
    }

    private void StopJump(InputAction.CallbackContext ctx)
    {
        jumpInput = false;
    }
}
