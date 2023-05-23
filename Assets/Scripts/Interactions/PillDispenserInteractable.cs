using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillDispenserInteractable : InteractablePlace
{
   
    public override void Interact()
    {
        Inventory.Instance.SetItem(this.gameObject);
        if (!infinite)
        {
            Destroy(this);
        }
        

    }
}
