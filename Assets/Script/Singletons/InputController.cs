using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public static InputController instance;

    #region KeyCodes
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";
    private KeyCode jump = KeyCode.Space;
    private KeyCode shoot = KeyCode.Mouse0;
    private KeyCode dash = KeyCode.LeftShift;
    private KeyCode pause = KeyCode.Escape;
    #endregion

    #region Events
    public Action OnPause;
    public Action OnShoot;
    public Action OnDash;
    public Action OnJump;
    public Action<float, float> OnMove; //horizontal, vertical
    #endregion

    #region Unity
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (!GameManager.instance.IsGameFreeze)
        {
            CheckMovement();
            CheckJump();
            CheckShoot();
            CheckDash();
        }

        CheckPause();
    }
    #endregion

    #region Private
    private void CheckMovement()
    {
        float horizontal = Input.GetAxisRaw(horizontalAxis);
        float vertical = Input.GetAxisRaw(verticalAxis);

        if(vertical !=  0 || horizontal != 0)
            OnMove?.Invoke(horizontal, vertical);
    }
    private void CheckShoot()
    {
        if (Input.GetKeyDown(shoot))
            OnShoot?.Invoke();
    }
    private void CheckJump()
    {
        if (Input.GetKeyDown(jump))
            OnJump?.Invoke();
    }
    private void CheckDash()
    {
        if (Input.GetKeyDown(dash))
            OnDash?.Invoke();
    }

    private void CheckPause()
    {
        if (Input.GetKeyDown(pause))
            OnPause?.Invoke();
    }
    #endregion
}
