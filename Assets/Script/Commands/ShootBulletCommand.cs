using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBulletCommand : ICommand
{
    private GameObject ammoPrefab;
    private Transform shootingPoint;

    public ShootBulletCommand(GameObject prefab, Transform position)
    {
        ammoPrefab = prefab;
        shootingPoint = position;
    }

    public void Do()
    {
        
    }

    public void UnDo()
    {
        //Se la vuelve a meter en la lista y toda la chachara
    }

    
}
