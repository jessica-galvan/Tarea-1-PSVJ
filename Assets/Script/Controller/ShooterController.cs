using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [Header("Ammo")]
    [SerializeField] private GameObject ammoPrefab;
    [SerializeField] private int maxAmmo = 5;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float cdShoot;
    private bool canShoot;
    private float cdtimer;

    void Start()
    {
        currentAmmo = maxAmmo;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdtimer < Time.deltaTime)
            canShoot = true;
    }

    public void RechargeAmmo(int ammo)
    {
        if (currentAmmo < maxAmmo)
        {
            if (currentAmmo < (maxAmmo - ammo))
                currentAmmo += ammo;
            else
                currentAmmo = maxAmmo;
        }
    }

    public bool CanRechargeAmmo()
    {
        return currentAmmo < maxAmmo;
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
