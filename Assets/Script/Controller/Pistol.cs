using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    void Start()
    {
        CurrentAmmo = _gunStats.MaxAmmo;
    }

    private void Update()
    {
        if (timerCD < Time.deltaTime)
            CanAttack = true;
    }

    public override void Attack()
    {
        AttackCommand attack = new AttackCommand(this);
        GameManager.instance.AddEvent(attack);
    }

    public override void Reload(int number)
    {
        RechargeAmmoCommand recharge = new RechargeAmmoCommand(this, number);
        GameManager.instance.AddEvent(recharge);
    }

    public override void InstantiateBullets()
    {
        for (int i = 0; i < bulletsPerShoot; i++)
        {
            Instantiate(ammoPrefab, transform.position, transform.rotation);
        }

        timerCD = _gunStats.Cooldown + Time.deltaTime;
    }
}
