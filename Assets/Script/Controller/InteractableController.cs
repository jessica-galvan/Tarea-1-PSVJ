using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviour
{
    public IInteractable interactable;

    private void OnTriggerEnter(Collider other)
    {
        Character player = other.gameObject.GetComponent<Character>();
        if (player != null)
        {
            interactable.Interact(player);
        }
    }
}
