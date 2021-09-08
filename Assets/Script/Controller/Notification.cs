using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Notification
{
    private ISubject _sender;
    private ICommand _command;

    ISubject Sender => _sender;
    ICommand Command => _command;

    public Notification(ISubject subject, ICommand command)
    {
        _sender = subject;
        _command = command;
    }
}
