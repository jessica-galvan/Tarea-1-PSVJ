using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeController))]
[RequireComponent(typeof(ShooterController))]
public class Character : MonoBehaviour
{
    [Header("Extras")]
    [SerializeField] private int coins = 0;
    public int Coins => coins;

    public LifeController LifeController { get; private set; }
    public ShooterController ShooterController { get; private set; }

    void Start()
    {
        LifeController = GetComponent<LifeController>();
        ShooterController = GetComponent<ShooterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ShooterController.Shoot();
    }

    public void AddCoins(int value)
    {
        coins += value;
    }
}
