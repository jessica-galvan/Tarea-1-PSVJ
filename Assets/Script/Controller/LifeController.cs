using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int currentLife;
    
    private ActorStats stats;

    public int MaxLife => stats.MaxLife;
    public int CurrentLife => currentLife;

    public Action OnDie;
    public Action<int> OnTakeDamage;
    public Action<int> OnHeal;

    public void SetStats(ActorStats stats)
    {
        this.stats = stats;
        currentLife = stats.MaxLife;
    }

    public bool CanHeal()
    {
        return currentLife < MaxLife;
    }

    public void Heal(int heal)
    {
        if (currentLife < MaxLife && currentLife > 0)
        {
            if (currentLife < (MaxLife - heal))
                currentLife += heal;
            else
                currentLife = MaxLife;

            OnHeal?.Invoke(currentLife);
        }
    }
    public void TakeDamage(int damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
            OnTakeDamage?.Invoke(currentLife);
            CheckLife();
        }
    }

    private void CheckLife()
    {
        if (currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDie?.Invoke();
    }
}
