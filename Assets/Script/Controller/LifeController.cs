using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [Header("Life")]
    [SerializeField] private int currentLife;
    [SerializeField] protected ActorStats _actorStats;

    public int MaxLife => _actorStats.MaxLife;
    public int CurrentLife => currentLife;

    void Start()
    {
        currentLife = MaxLife;
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
