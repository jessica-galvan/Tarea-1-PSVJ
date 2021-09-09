using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //Character
    [SerializeField] private Character character;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //KEYCODES
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private KeyCode jump = KeyCode.Space;
    private KeyCode shoot = KeyCode.Mouse0;
    private KeyCode dash = KeyCode.LeftShift;
    private KeyCode pause = KeyCode.Escape;

    //EVENTS
    public Action OnPause;

    private void Start()
    {
        character = GameManager.instance.Player;
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

        CheckPause();
    }

    private void CheckMovement()
    {
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        float vertical = Input.GetAxisRaw(verticalAxis);

        if(vertical !=  0 || horizontal != 0)
        {
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            character.transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            character.MovementController.Move(direction);
        }
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

    public void CheckPause()
    {
        if (Input.GetKeyDown(pause))
        {
            OnPause?.Invoke();
        }
    }
}
