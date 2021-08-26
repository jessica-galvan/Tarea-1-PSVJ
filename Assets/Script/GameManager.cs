using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //SINGLETON
    public static GameManager instance;

    //EVENTS
    private List<ICommand> _events = new List<ICommand>();

    //VARIABLES
    public bool isGameFreeze;

    public void AddEvent(ICommand command)
    {
        _events.Add(command);
    }

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        for (int i = _events.Count - 1; i >= 0 ; i++) //EVENT QUEUE
        {
            _events[i].Do();
            _events.RemoveAt(i);
        }
    }

}
