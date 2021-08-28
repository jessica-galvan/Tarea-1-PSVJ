using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeController))]
public class Character : MonoBehaviour
{
    [Header("Ammo")]
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private int maxAmmo = 5;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float cdShoot;
    private bool canShoot;
    private float cdtimer;

    [Header("Extras")]
    [SerializeField] private int coins = 0;
    public int Coins => coins;

    public LifeController LifeController { get; private set; }

    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
        LifeController = GetComponent<LifeController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();

        if (cdtimer < Time.deltaTime)
            canShoot = true;
    }

    public void RechargeAmmo(int ammo)
    {
        if(currentAmmo < maxAmmo)
        {
            if(currentAmmo < (maxAmmo - ammo))
                currentAmmo += ammo;
            else
                currentAmmo = maxAmmo;
        }
    }

    public bool CanRechargeAmmo()
    {
        return currentAmmo < maxAmmo;
    }

    public void AddCoins(int value)
    {
        coins += value;
    }

    public void Shoot()
    {
        if (canShoot && currentAmmo > 0)
        {
            //canShoot = false;
            cdtimer = cdShoot + Time.deltaTime;
            currentAmmo -= 1;
            Instantiate(ammoPrefab, transform.position, transform.rotation);
        }
    }
}
