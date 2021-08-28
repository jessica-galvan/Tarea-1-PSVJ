using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class RechargeAmmoCommand: ICommand
{
    private Gun _gun;
    private int _rechargeAmmo;

    public RechargeAmmoCommand(Gun gun, int rechargeAmmoNumber)
    {
        _gun = gun;
        _rechargeAmmo = rechargeAmmoNumber;
    }

    public void Do()
    {
        if (_gun.CurrentAmmo < _gun.MaxAmmo)
        {
            if (_gun.CurrentAmmo < (_gun.MaxAmmo - _rechargeAmmo))
                _gun.CurrentAmmo += _rechargeAmmo;
            else
                _gun.CurrentAmmo = _gun.MaxAmmo;
        }
    }
}
