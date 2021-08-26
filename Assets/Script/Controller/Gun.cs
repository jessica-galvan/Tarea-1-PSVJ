using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    [SerializeField] protected GunStats _gunStats;
    protected int _currentAmmo;
    protected bool _canAttack;
    protected float timerCD;

    protected AttackCommand _attackCommand;



    public abstract void Attack();

    public abstract void Reload();
}
