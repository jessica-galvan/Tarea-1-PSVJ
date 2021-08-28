using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    //VARIABLES
    [SerializeField] protected GunStats _gunStats;
    [SerializeField] protected GameObject ammoPrefab;
    protected float timerCD;
    protected bool canShoot;
    protected int bulletsPerShoot;

    //COMMANDS
    protected AttackCommand _attackCommand;
    protected RechargeAmmoCommand _rechargeCommand;

    //PROPIEDADES
    public int CurrentAmmo { get; set; }
    public bool CanAttack { get; set; }
    public int MaxAmmo => _gunStats.MaxAmmo;
    public int Damage => _gunStats.Damage;

    //METODOS
    public abstract void Attack();
    public abstract void Reload(int number);
    public abstract void InstantiateBullets();
}
