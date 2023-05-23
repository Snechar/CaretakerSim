using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractablePlace : MonoBehaviour
{
    public bool infinite;
    abstract public void Interact();

}
