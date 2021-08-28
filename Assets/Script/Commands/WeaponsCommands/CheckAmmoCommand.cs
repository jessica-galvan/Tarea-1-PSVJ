using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAmmoCommand : MonoBehaviour
{
    private Gun _gun;

    public CheckAmmoCommand(Gun gun)
    {
        _gun = gun;
    }

    public void Do()
    {
        //_gun.CurrentAmmo < _gun.MaxAmmo;
    }
}
