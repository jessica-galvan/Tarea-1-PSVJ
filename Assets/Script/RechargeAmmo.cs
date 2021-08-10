using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeAmmo : MonoBehaviour, IInteractable
{
    [SerializeField] private int ammo;


    void Start()
    {
        GetComponent<InteractableController>().interactable = this;
    }

    public void Interact(Character character)
    {
        if (character.CanRechargeAmmo())
        {
            character.RechargeAmmo(ammo);
            Destroy(gameObject);
        }
    }

}
