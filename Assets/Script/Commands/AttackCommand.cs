using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Gun _gun;

    public AttackCommand(Gun gun)
    {
        _gun = gun;
    }

    public void Do()
    {
        _gun.Attack();
    }
}
