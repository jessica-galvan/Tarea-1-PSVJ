using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    List<IObserver> Observer { get; }

    void Subscribe(IObserver observer);
    void Unsuscribe(IObserver observer);
    void SendNofitication(Notification notification);
}
