using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeController))]
[RequireComponent(typeof(MovementController))]
public class Actor : MonoBehaviour, IDamagable
{
    [SerializeField] protected ILife _actorStats;

    private float _currentSpeed;
    private float _speedMultiplierDuration;
    private bool isSpeedBuffed;

    public LifeController LifeController { get; private set; }
    public MovementController MoveController { get; private set; }


    void Start()
    {
        LifeController = GetComponent<LifeController>();
        MoveController = GetComponent<MovementController>();
        InitStats();
    }

    private void InitStats()
    {
        _currentSpeed = _actorStats.Speed;
        LifeController.OnDie += Die;
    }


    public void MultiplySpeed(float multiplier, float duration)
    {
        _currentSpeed *= multiplier;
        _speedMultiplierDuration = duration;
    }

    void Update()
    {
        if (isSpeedBuffed)
        {
            _speedMultiplierDuration -= Time.deltaTime;
            if (_speedMultiplierDuration <= 0)
            {
                _currentSpeed = _actorStats.Speed;
                isSpeedBuffed = false;
            }
        }
    }


    public void Die()
    {
        Destroy(gameObject);
    }

}
