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

    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

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

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        character.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        character.MovementController.Move(direction);

        //character.MovementController.MoveCharacter(horizontal, vertical);
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
