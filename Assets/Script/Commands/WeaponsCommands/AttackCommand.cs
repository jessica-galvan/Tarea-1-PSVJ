using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Gun _gun;
    private int bulletsPerShoot;


    public AttackCommand(Gun gun)
    {
        _gun = gun;
    }

    public void Do()
    {
        if (_gun.CanAttack && _gun.CurrentAmmo >= bulletsPerShoot)
        {
            _gun.CanAttack = false;
            _gun.CurrentAmmo -= bulletsPerShoot;

            _gun.InstantiateBullets();
        }
    }
}
