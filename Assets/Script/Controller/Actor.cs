using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField] protected ActorStats _actorStats;

    private int _currentLife;
    private float _currentSpeed;
    private float _speedMultiplierDuration;
    private bool isSpeedBuffed;

    public int MaxLife => _actorStats.MaxLife;
    public int CurrentLife => _currentLife;
    

    //COMMANDS
    private MoveCommand _moveFowardCommand;
    private MoveCommand _moveBackwardCommand;
    private MoveCommand _moveLeftCommand;
    private MoveCommand _moveRightCommand;

    // Start is called before the first frame update
    void Start()
    {
        InitStats();
        InitCommands();
    }

    private void InitStats()
    {
        _currentLife = _actorStats.MaxLife;
        _currentSpeed = _actorStats.Speed;
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

    // Update is called once per frame
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

    public void TakeDamage (int damage)
    {

    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
