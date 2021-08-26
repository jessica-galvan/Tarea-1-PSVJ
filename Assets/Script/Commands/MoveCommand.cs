using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector3 _direction;
    private Transform _subject;
    private float _speed;

    public MoveCommand(Transform subject, Vector3 direction, float speed)
    {
        _subject = subject;
        _direction = direction;
        _speed = speed;
    }

    public void Do()
    {
        _subject.position += _direction * _speed * Time.deltaTime;
    }
}
