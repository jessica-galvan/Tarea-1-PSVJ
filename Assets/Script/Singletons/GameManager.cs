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
    public bool IsGameFreeze { get; set; }


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
        inputController.AssingCharacter(character);
    }
}
