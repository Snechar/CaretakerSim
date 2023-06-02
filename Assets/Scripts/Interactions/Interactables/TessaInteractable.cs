using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TessaInteractable : InteractablePlace
{
    public override void Interact(GameObject original)
    {
        Inventory.Instance.SetItem(this.gameObject);
        if (!infinite || hasBeenPlacedDown)
        {
            Destroy(this.gameObject);
        }
        if (hasBeenPlacedDown)
        {

            needManager.AddNeed(new PillsNeed());
            if (original.GetComponentInParent<PlacementScript>().hasItem)
            {
                original.GetComponentInParent<PlacementScript>().hasItem = false;
            }

        }
    }

    public override void OnPlaceDown(NPCNeedManager need)
    {
        need.RemoveNeed(new TessaNeed());
    }
}
