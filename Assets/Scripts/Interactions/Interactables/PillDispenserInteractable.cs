using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillDispenserInteractable : InteractablePlace
{



    public override void Interact()
    {
        Inventory.Instance.SetItem(this.gameObject);
        if (!infinite || hasBeenPlacedDown)
        {
            Destroy(this.gameObject);
        }
        if (hasBeenPlacedDown)
        {
            needManager.AddNeed(new PillsNeed());
        }
        

    }

    public override void OnPlaceDown(NPCNeedManager need)
    {
        need.RemoveNeed(new PillsNeed());

    }
}
