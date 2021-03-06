using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeAmmo : MonoBehaviour, IInteractable
{
    [SerializeField] protected InteractableStats _interactableStats;

    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        if (character.CanRechargeAmmo())
        {
            character.RechargeAmmo(_interactableStats.RechargeAmmo);
            Destroy(gameObject);
        }
    }

}