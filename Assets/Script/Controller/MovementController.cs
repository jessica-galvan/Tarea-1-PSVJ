using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float currentSpeed;

    //PRIVATE VARIABLES
    private ActorStats _actorStats;
    private bool isSprinting;
    private bool canJump;

    public void SetStats(ActorStats stats)
    {
        _actorStats = stats;
        currentSpeed = _actorStats.OriginalSpeed;
    }

    public void Move(Vector3 direction)
    {
        transform.position += (direction * (currentSpeed * Time.deltaTime));
    }

    public void Jump()
    {
        if (_actorStats.CanJump)
        {
            //TODO: JUMP without physics (or movement by physics)
        }
    }

    public void CheckIfGrounded()
    {
        //TODO: Raycast to check if is grounded
    }

    public void Sprint()
    {
        currentSpeed = isSprinting ? _actorStats.OriginalSpeed : _actorStats.BuffedSpeed;
    }

    //public void MoveCharacter(float horizontal, float vertical)
    //{
    //    Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

    //    if (direction.magnitude >= 0.1f)
    //    {
    //        //float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    //        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
    //        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
    //        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

    //        //Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

    //        //controller.Move(moveDirection.normalized * currentSpeed * Time.deltaTime);

    //        //transform.position += (moveDirection.normalized * (currentSpeed * Time.deltaTime));

    //        Move(direction);
    //    }
    //}
}
