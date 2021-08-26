using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header ("Life")]
    [SerializeField] private int maxLife = 100;
    [SerializeField] private int currentLife;

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


    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        currentLife = maxLife;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if(cdtimer < Time.deltaTime)
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

    public void Heal(int heal)
    {
        if(currentLife < maxLife && currentLife > 0)
        {
            if (currentLife < (maxLife - heal))
                currentLife += heal;
            else
                currentLife = maxLife;
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
            CheckLife();
        }
    }

    public void CheckLife()
    {
        if(currentLife <= 0)
        {
            print("GameOver");
        }
    }

    public bool CanRechargeAmmo()
    {
        return currentAmmo < maxAmmo;
    }

    public bool CanHeal()
    {
        return currentLife < maxLife;
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
