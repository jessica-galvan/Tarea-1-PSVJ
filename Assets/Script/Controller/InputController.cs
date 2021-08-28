using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private MovementController moveController;

    private void Start()
    {
        moveController = GetComponent<MovementController>();
    }

    private void Update()
    {
        CheckMovement();
        CheckJump();
    }

    private void CheckMovement()
    {
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        float vertical = Input.GetAxisRaw(verticalAxis);

        moveController.CalculateMovement(horizontal, vertical);
    }
    private void CheckJump()
    {
        //TODO: JUMP
    }
}
