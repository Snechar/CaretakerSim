using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractablePlace : MonoBehaviour
{
    public bool hasBeenPlacedDown = false;
    public NPCNeedManager needManager;
    public bool infinite;
    abstract public void Interact();
    abstract public void OnPlaceDown(NPCNeedManager need);

}
