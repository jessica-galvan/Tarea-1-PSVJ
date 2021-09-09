using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterController))]
public class Character : Actor, IDamagable
{
    [SerializeField] private int coins = 0;

    public int Coins => coins;
    public ShooterController ShooterController { get; private set; }

    void Awake()
    {
        ShooterController = GetComponent<ShooterController>();
        SubscribeEvents();
    }

    public override void Start()
    {
        base.Start();
        GameManager.instance.AssingCharacter(this);
    }

    private void SubscribeEvents()
    {
        //TODO: cuando haya un particle system, reaccionar a LifeController. 
    }

    public void AddCoins(int value)
    {
        coins += value;
    }

    private void OnDie()
    {
        //Destroy? Respawn? Animation? Whatever.
    }
}
