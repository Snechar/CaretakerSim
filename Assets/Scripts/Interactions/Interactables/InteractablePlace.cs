using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractablePlace : MonoBehaviour
{
    public bool hasBeenPlacedDown = false;
    public NPCNeedManager needManager;
    public bool infinite;
    public TechnologyDataScriptableObject technologyDataScriptableObject;
    abstract public void Interact(GameObject original);
    abstract public void OnPlaceDown(NPCNeedManager need);

}
