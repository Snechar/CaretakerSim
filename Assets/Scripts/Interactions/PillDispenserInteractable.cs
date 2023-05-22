using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillDispenserInteractable : InteractablePlace
{
    public bool infinite = true;
    public override void Interact()
    {
        Debug.Log("Yippie2");
    }
}
