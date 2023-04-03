using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableEnum
{
    Bed,
    Toilet,
    Food,
    Pasttime,
    Technology
}

public abstract class Interactable : MonoBehaviour
{
    public abstract GameObject interactionObject { get; set; }
    abstract public void OnUse(NPCStats npc);
    public abstract ManagerBase GetManager(NPCStats npc);
}
