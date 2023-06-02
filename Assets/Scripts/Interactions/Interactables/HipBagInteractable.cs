using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipBagInteractable : InteractablePlace
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
            needManager.AddNeed(new HipBagNeed());
        }
    }

    public override void OnPlaceDown(NPCNeedManager need)
    {
        need.RemoveNeed(new HipBagNeed());
    }
}
