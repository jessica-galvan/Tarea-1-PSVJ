using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeHeal : MonoBehaviour, IInteractable
{
    [SerializeField] protected InteractableStats _interactableStats;
    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        if (character.CanHeal())
        {
            character.Heal(_interactableStats.Heal);
            Destroy(gameObject);
        }
    }
}
