using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Character character;
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private KeyCode jump = KeyCode.Space;
    private KeyCode shoot = KeyCode.Mouse0;
    private KeyCode dash = KeyCode.LeftShift;

    private void Start()
    {

    }

    private void Update()
    {
        if (!GameManager.instance.IsGameFreeze && character != null)
        {
            CheckMovement();
            CheckJump();
            CheckShoot();
            CheckDash();
        }
    }

    private void CheckMovement()
    {
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        float vertical = Input.GetAxisRaw(verticalAxis);

        character.MovementController.Move(horizontal, vertical);
    }
    private void CheckShoot()
    {
        if (Input.GetKeyDown(shoot))
            character.ShooterController.Shoot();
    }
    private void CheckJump()
    {
        if (Input.GetKeyDown(jump))
        {
            //TODO: JUMP
        }
    }
    private void CheckDash()
    {
        if (Input.GetKeyDown(dash))
        {
            //TODO: Implement Dash
        }
    }

    public void AssingCharacter(Character character)
    {
        this.character = character;
    }
}
