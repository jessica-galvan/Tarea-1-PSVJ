using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ScoreManager : MonoBehaviour, ISubject
{
    //SINGLETON
    public static ScoreManager instance;

    //OBSERVER
    private List<IObserver> observers = new List<IObserver>();
    public List<IObserver> Observer => observers;

    //Score
    private int score;
    public int Score => score;

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
        if (Input.GetKeyDown(KeyCode.Space))
            AddScore(1);
    }

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsuscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void SendNofitication(Notification notification)
    {
        foreach (var item in observers)
        {
            item.RecieveNotification(notification);
        }
    }

    public void AddScore(int newscore)
    {
        score += newscore;
    }
}
