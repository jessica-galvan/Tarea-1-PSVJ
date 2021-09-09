using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeController))]
[RequireComponent(typeof(ShooterController))]
[RequireComponent(typeof(MovementController))]
public class Character : MonoBehaviour, IDamagable
{
    [SerializeField] private ILife actorStats;
    [SerializeField] protected ActorStats _actorStats;
    [SerializeField] private int coins = 0;

    public int Coins => coins;
    public LifeController LifeController { get; private set; }
    public ShooterController ShooterController { get; private set; }
    public MovementController MovementController { get; private set; }

    void Awake()
    {
        LifeController = GetComponent<LifeController>();
        ShooterController = GetComponent<ShooterController>();
        MovementController = GetComponent<MovementController>();
        LifeController.SetStats(_actorStats);

        SubscribeEvents();
    }

    void Start()
    {
        GameManager.instance.AssingCharacter(this);
    }

    public void AddCoins(int value)
    {
        coins += value;
    }

    private void SubscribeEvents()
    {
        LifeController.OnDie += OnDie;
        //TODO: cuando haya un particle system, reaccionar a LifeController. 
    }

    private void OnDie()
    {
        //Destroy? Respawn? Animation? Whatever.
    }
}
