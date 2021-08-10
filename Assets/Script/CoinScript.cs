using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour,IInteractable
{
    [SerializeField] private int value = 1;

    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        character.AddCoins(value);
        Destroy(gameObject);
    }
}
