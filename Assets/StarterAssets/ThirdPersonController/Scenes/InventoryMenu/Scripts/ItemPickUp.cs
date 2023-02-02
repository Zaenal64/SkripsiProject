using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour, IInteractable
{
    public Item item;
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;

    public void Interact(Interactor interactor)
    {
       PickUp();
    }

    private void PickUp()
    {
        Debug.Log("picking up "+ item.name);
        //store to inventory
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp){
            Destroy(gameObject);
            Debug.Log("Destroy Item after picking " + item.name);
        }
        
    }
}
