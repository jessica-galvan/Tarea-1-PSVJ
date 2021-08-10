using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour, IInteractable
{
    [SerializeField] int damage = 10;

    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        print("hola");
        character.TakeDamage(damage);
    }
}
