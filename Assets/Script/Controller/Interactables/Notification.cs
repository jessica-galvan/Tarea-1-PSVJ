using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
