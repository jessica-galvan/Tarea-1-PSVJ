using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GunStats _gunStats;
   
    void Update()
    {
        transform.position += transform.forward * _gunStats.Speed * Time.deltaTime;
    }
}
