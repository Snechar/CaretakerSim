using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipBagInteractableTrigger : MonoBehaviour
{
    private bool peterTheHorseIsHere = false;
    public NPCStats npc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Inventory.Instance.item != null)
        {
            if (Inventory.Instance.item.GetComponent<InteractablePlace>().GetType().ToString() == "HipBagInteractable")
            {
                CanvasController.Instance.EnableInteractText();
                CanvasController.Instance.shouldRemove = false;
                peterTheHorseIsHere = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanvasController.Instance.DisableInteractText();
            CanvasController.Instance.shouldRemove = true;
            peterTheHorseIsHere = false;
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Inventory.Instance.item != null)
        {
            if (Inventory.Instance.item.GetComponent<InteractablePlace>().GetType().ToString() == "HipBagInteractable")
            {
                CanvasController.Instance.EnableInteractText();
                CanvasController.Instance.shouldRemove = false;
                peterTheHorseIsHere = true;
            }
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && Inventory.Instance.item != null && peterTheHorseIsHere)
        {
            Debug.Log("tried to attach hipbag");
            Inventory.Instance.item.GetComponent<InteractablePlace>().OnPlaceDown(this.transform.parent.GetComponent<NPCNeedManager>());
            GameObject objectToPlace = Inventory.Instance.item;
            GameObject currentObject = Instantiate(objectToPlace);
            currentObject.transform.position = new Vector3(0, 0, 0);
            currentObject.transform.SetParent(this.transform, false);
            currentObject.GetComponent<BoxCollider>().enabled = true;
            currentObject.GetComponent<InteractablePlace>().infinite = false;
            currentObject.GetComponent<InteractablePlace>().needManager = this.transform.parent.GetComponent<NPCNeedManager>();
            currentObject.GetComponent<InteractablePlace>().hasBeenPlacedDown = true;
            Inventory.Instance.RemoveItem();
        }
    }
}
