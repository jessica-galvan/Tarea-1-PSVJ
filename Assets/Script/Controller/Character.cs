using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeController))]
[RequireComponent(typeof(ShooterController))]
[RequireComponent(typeof(MovementController))]
public class Character : MonoBehaviour, IDamagable, IObserver
{
    [SerializeField] private ILife actorStats;
    [SerializeField] protected ActorStats _actorStats;
    [SerializeField] private int coins = 0;

    public int Coins => coins;
    public bool IsMuted { get; private set; }
    public LifeController LifeController { get; private set; }
    public ShooterController ShooterController { get; private set; }
    public MovementController MovementController { get; private set; }

    void Awake()
    {
        LifeController = GetComponent<LifeController>();
        ShooterController = GetComponent<ShooterController>();
        MovementController = GetComponent<MovementController>();
        LifeController.SetStats(_actorStats);
    }

    void Start()
    {
        GameManager.instance.AssingCharacter(this);
        ScoreManager.instance.Subscribe(this);
        GameManager.instance.Subscribe(this);
    }

    public void AddCoins(int value)
    {
        coins += value;
    }

    public void RecieveNotification(Notification notification)
    {
        throw new System.NotImplementedException();
    }

    public void Mute()
    {
        IsMuted = true;
    }

    public void Unmute()
    {
        IsMuted = false;
    }
}
