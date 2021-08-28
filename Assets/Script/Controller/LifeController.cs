using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int currentLife;
    
    private ILife stats;

    public int MaxLife => stats.MaxLife;
    public int CurrentLife => currentLife;

    public void SetStats(ILife stats)
    {
        print(stats.MaxLife);
        this.stats = stats;
        currentLife = stats.MaxLife;
        print(MaxLife);
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
        }
    }
    public void TakeDamage(int damage)
    {
        if (currentLife > 0)
        {
            currentLife -= damage;
            CheckLife();
        }
    }

    public void CheckLife()
    {
        if (currentLife <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        print("GameOver");
        // Destroy(gameObject);
        //Event???
    }
}
