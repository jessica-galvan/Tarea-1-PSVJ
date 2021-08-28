using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Gun _gun;
    private int bulletsPerShoot;
    private Transform _shootingPoint;


    public AttackCommand(Gun gun, Transform shootPoint)
    {
        _gun = gun;
        _shootingPoint = shootPoint;
    }

    public void Do()
    {
        if (_gun.CanAttack && _gun.CurrentAmmo >= bulletsPerShoot)
        {
            _gun.CanAttack = false;
            _gun.CurrentAmmo -= bulletsPerShoot;

            _gun.InstantiateBullets(_shootingPoint);
        }
    }
}
