﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private int bulletsQuantity;
    private Pool<Bullet> bulletList; //Si hay más bullets, hacer una clase base de bullets para que hereden, no usar interface.

    public BulletManager(int quantity)
    {
        Initializer(quantity);
    }

    public void Initializer(int quantity)
    {
        bulletsQuantity = quantity;

        var list = new List<Bullet>();
        for (int i = 0; i < bulletsQuantity; i++)
        {
            var bullet = BulletFactory.instance.CreateBullet();
            list.Add(bullet);
        }

        bulletList =  new Pool<Bullet>(list);
    }

    void Update()
    {
        foreach (var item in bulletList.GetInUseItems())
        {
            if (item.CanReturn)
                StoreBullet(item);
        }
    }

    public Bullet GetBullet()
    {
        return bulletList.GetInstance();
    }

    public void StoreBullet(Bullet bullet)
    {
        bullet.CanReturn = false;
        bulletList.Store(bullet);
        //Maybe move position;
    }
}