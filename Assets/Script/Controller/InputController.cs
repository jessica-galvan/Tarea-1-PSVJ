using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private KeyCode jump = KeyCode.Space;
    private KeyCode shoot = KeyCode.Mouse0;
    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        if (!GameManager.instance.isGameFreeze)
        {
            CheckMovement();
            CheckJump();
            CheckShoot();
        }
    }

    private void CheckMovement()
    {
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        float vertical = Input.GetAxisRaw(verticalAxis);

        character.MovementController.Move(horizontal, vertical);
    }
    private void CheckJump()
    {
        if (Input.GetKeyDown(jump))
        {
            //TODO: JUMP
        }
    }

    private void CheckShoot()
    {
        if (Input.GetKeyDown(shoot))
            character.ShooterController.Shoot();
    }
}
