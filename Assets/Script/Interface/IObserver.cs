using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    bool IsMuted { get; }

    void RecieveNotification(Notification notification);

    void Mute();
    void Unmute();
}
