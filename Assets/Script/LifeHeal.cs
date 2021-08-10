using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHeal : MonoBehaviour, IInteractable
{
    [SerializeField] private int heal;

    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        if (character.CanHeal())
        {
            character.Heal(heal);
            Destroy(gameObject);
        }
    }
}
