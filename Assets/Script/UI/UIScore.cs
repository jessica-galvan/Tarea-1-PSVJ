using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour, IObserver
{
    [SerializeField] private Text scoreText;
    public bool IsMuted { get; private set; }

    void Start()
    {
        ScoreManager.instance.Subscribe(this);
    }

    public void Mute()
    {
        IsMuted = true;
    }

    public void RecieveNotification(Notification notification)
    {
        //si el command de la notifiacion es que se agrego un score, actualizamos el score.
    }

    public void Unmute()
    {
        IsMuted = false;
    }

    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
