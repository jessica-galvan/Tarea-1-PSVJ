using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //SINGLETON
    public static GameManager instance;

    //SERIALIZED FIELDS
    [SerializeField] private Character character;

    //VARIABLES
    private InputController inputController;

    //PROPIEDADES
    public bool IsGameFreeze { get; private set; }

    public string CurrentLevel { get; private set; }
    public Character Player => character;
    public InputController InputController => inputController;

    //EVENTS
    public Action OnPause;


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

    public void AssingCharacter(Character character)
    {
        this.character = character;
        character.LifeController.OnDie += GameOver;
    }
    public void GameOver()
    {
        character.LifeController.OnDie -= GameOver;
        //TODO: Change Scene, respawn, whatever.
    }

    public void Pause(bool value)
    {
        IsGameFreeze = value;
        if (value)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
