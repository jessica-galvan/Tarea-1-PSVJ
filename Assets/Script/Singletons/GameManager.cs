using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, ISubject
{
    //SINGLETON
    public static GameManager instance;

    //SERIALIZED FIELDS
    [SerializeField] private Character character;

    //EVENTS
    private List<ICommand> _events = new List<ICommand>();

    //VARIABLES
    private InputController inputController;


    //PROPIEDADES
    public bool IsGameFreeze { get; set; }

    public List<IObserver> Observer => _subscriptions;
    private List<IObserver> _subscriptions = new List<IObserver>();


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

        inputController = GetComponent<InputController>();
    }

    private void Update()
    {
        for (int i = _events.Count - 1; i >= 0; i--) //EVENT QUEUE
        {
            _events[i].Do();
            _events.RemoveAt(i);
        }
    }

    public void Subscribe(IObserver observer)
    {
        _subscriptions.Add(observer);
    }

    public void Unsuscribe(IObserver observer)
    {
        _subscriptions.Remove(observer);
    }

    public void SendNofitication(Notification notification)
    {
        for (int i = _subscriptions.Count - 1;  i > 0; i--)
        {
            if (!_subscriptions[i].IsMuted)
                _subscriptions[i].RecieveNotification(notification);
        }
    }

    public void AssingCharacter(Character character)
    {
        this.character = character;
        inputController.AssingCharacter(character);
    }
}
