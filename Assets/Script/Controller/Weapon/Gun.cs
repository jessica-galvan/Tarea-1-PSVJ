using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    //VARIABLES
    [SerializeField] protected GunStats _gunStats;
    [SerializeField] protected GameObject ammoPrefab;
    [SerializeField] protected int bulletsPerShoot = 1;
    protected float timerCD;
    protected bool canShoot;

    //COMMANDS
    protected AttackCommand _attackCommand;
    protected RechargeAmmoCommand _rechargeCommand;

    //PROPIEDADES
    public int CurrentAmmo { get; set; }
    public bool CanAttack { get; set; }
    public IOwner Owner { get; protected set; }
    public int MaxAmmo => _gunStats.MaxAmmo;
    public int Damage => _gunStats.Damage;
    public float Cooldown => _gunStats.Cooldown;

    //METODOS
    public abstract void Attack();
    public abstract void Reload(int number);
    public abstract void InstantiateBullets(Transform shootingPoint);

    public void SetOwner(IOwner owner)
    {
        Owner = owner;
    }
}
