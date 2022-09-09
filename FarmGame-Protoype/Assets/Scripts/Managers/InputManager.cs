using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;

    Vector2 movementInput;

    float horizontalInput;
    float vericalInput;

    public Vector2 moveAmount;
    private void Awake() 
    {
        
    }
    private void OnEnable() 
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.Player.Move.performed += i => movementInput = i.ReadValue<Vector2>();

        }

        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void AllMovement()
    {
        MovementInput();   
    }

    void MovementInput()
    {
        horizontalInput = movementInput.x;
        vericalInput = movementInput.y;

        moveAmount = new Vector2(horizontalInput, vericalInput);
    }
}
