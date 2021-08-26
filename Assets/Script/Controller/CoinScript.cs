using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour,IInteractable
{
    [SerializeField] protected InteractableStats _interactableStats;

    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        print(character.Coins + " stat: " + _interactableStats.Coin);
        character.AddCoins(_interactableStats.Coin);
        print("Added coin result: " +character.Coins);
        Destroy(gameObject);
    }
}
