using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] protected ActorStats _actorStats;

    private float _currentSpeed;
    private float _speedMultiplierDuration;
    private bool isSpeedBuffed;

    public LifeController LifeController { get; private set; }

    //COMMANDS
    private MoveCommand _moveFowardCommand;
    private MoveCommand _moveBackwardCommand;
    private MoveCommand _moveLeftCommand;
    private MoveCommand _moveRightCommand;

    void Start()
    {
        InitStats();
        InitCommands();
    }

    private void InitStats()
    {
        _currentSpeed = _actorStats.Speed;
        LifeController = GetComponent<LifeController>();
    }

    private void InitCommands()
    {
        _moveFowardCommand = new MoveCommand(transform, transform.forward, _actorStats.Speed);
        _moveBackwardCommand = new MoveCommand(transform, -transform.forward, _actorStats.Speed);
        _moveBackwardCommand = new MoveCommand(transform, transform.right, _actorStats.Speed);
        _moveBackwardCommand = new MoveCommand(transform, -transform.right, _actorStats.Speed);
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

    public void Move(float inputX, float inputY)
    {
        //MAQUUINA DE ESTADOS
    }


    public void Die()
    {
        Destroy(gameObject);
    }

}
