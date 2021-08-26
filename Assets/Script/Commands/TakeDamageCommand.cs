using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCommand : ICommand
{
    private IDamagable _victim;
    private Actor _perpetrator;
    private int _damage;

    public TakeDamageCommand(Actor perpetrator, IDamagable victim, int damage)
    {
       _perpetrator = perpetrator;
       _victim = victim;
       _damage = damage;
    }

    public void Do()
    {
        //_victim.Cu      _currentLife -= _damage;
        //if (_currentLife <= 0)
        //{
        //    Die();
        //}
    }
}
