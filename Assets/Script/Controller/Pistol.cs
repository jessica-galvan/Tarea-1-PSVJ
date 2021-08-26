using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public int Damage => _gunStats.Damage;

    void Start()
    {
        _currentAmmo = _gunStats.MaxAmmo;
    }

    private void Update()
    {
        if (timerCD < Time.deltaTime)
            _canAttack = true;
    }

    public override void Attack()
    {
        //Instantiate a bullet with certain speed and cooldown of attack.
        if (_canAttack)
        {
            _canAttack = false;
            _currentAmmo--;
            //Do something.

            

            timerCD = _gunStats.Cooldown + Time.deltaTime;
        }
    }

    public override void Reload()
    {
        throw new System.NotImplementedException();
    }
}
