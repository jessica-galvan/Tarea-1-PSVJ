using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float originalSpeed;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private Transform cam;

    private float turnSmoothVelocity;
    private CharacterController controller;

    private float currentSpeed;
    private float buffedSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = originalSpeed;
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDirection.normalized * currentSpeed * Time.deltaTime);
        }
    }
}
