using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterController))]
public class PlayerController : Actor, IDamagable
{
    //Serializados
    [SerializeField] private int coins = 0;
    [SerializeField] private float turnSmoothTime = 0.1f;
    
    //Privados
    private float turnSmoothVelocity;

    //Propiedades
    public int Coins => coins;
    public ShooterController ShooterController { get; private set; }

    #region Unity
    void Awake()
    {
        ShooterController = GetComponent<ShooterController>();
    }

    public override void Start()
    {
        base.Start();
        SubscribeEvents();
        GameManager.instance.AssingCharacter(this);
    }
    #endregion

    #region Privados
    private void SubscribeEvents()
    {
        InputController.instance.OnMove += OnMove;
        InputController.instance.OnShoot += OnShoot;
        //InputController.instance.OnJump += OnJump
        //InputController.instance.OnDash += OnDash;

        //TODO: cuando haya un particle system, reaccionar a LifeController. 
    }

    private void OnDie()
    {
        //Destroy? Respawn? Animation? Whatever.
    }
    #endregion

    #region Publicos
    public void AddCoins(int value)
    {
        coins += value;
    }
    public void OnMove(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);

        MovementController.Move(direction);
    }

    public void OnShoot()
    {
        ShooterController.Shoot();
    }
    #endregion
}
