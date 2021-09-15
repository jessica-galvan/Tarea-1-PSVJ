using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float currentSpeed;

    //PRIVATE VARIABLES
    private ActorStats _actorStats;
    private Rigidbody rbody;
    private bool isSprinting;
    private float distance = 1.1f;
    private TrailRenderer trail;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        trail = GetComponent<TrailRenderer>();
    }

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
        if (_actorStats.CanJump && CheckIfGrounded())
        {
            var jumpForce = _actorStats.JumpForce * transform.up;
            rbody.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    public bool CheckIfGrounded()
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(transform.position, Vector3.down), out hit, distance);
        if(hit.collider != null)
            return true;
        else
            return false;
    }

    public void Sprint()
    {
        if (isSprinting)
        {
            currentSpeed = _actorStats.OriginalSpeed;
            isSprinting = false;
        }
        else
        {
            currentSpeed = _actorStats.BuffedSpeed;
            isSprinting = true;
        }
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
