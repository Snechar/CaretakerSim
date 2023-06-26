using AXGeometry;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public RoomManager roomManager;
    public Transform placingPosition;
    private bool peterTheHorseIsHere = false;
    private GameObject peterTheHorse;
    public bool hasItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Inventory.Instance.item != null)
        {
            if (Inventory.Instance.item.GetComponent<InteractablePlace>().GetType().ToString() != "HipBagInteractable")
            {
                CanvasController.Instance.EnableInteractText();
                CanvasController.Instance.shouldRemove = false;
                peterTheHorseIsHere = true;
                peterTheHorse = other.gameObject;
            }
        }


    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Inventory.Instance.item != null )
        {
            if (Inventory.Instance.item.GetComponent<InteractablePlace>().GetType().ToString() != "HipBagInteractable")
            {
                CanvasController.Instance.EnableInteractText();
                CanvasController.Instance.shouldRemove = false;
                peterTheHorseIsHere = true;
                peterTheHorse = other.gameObject;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        CanvasController.Instance.DisableInteractText();
        CanvasController.Instance.shouldRemove = true;
        peterTheHorseIsHere = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Inventory.Instance.item != null && peterTheHorseIsHere)
        {
            if (hasItem)
            {
                return;
            }
            Inventory.Instance.item.GetComponent<InteractablePlace>().OnPlaceDown(this.transform.parent.transform.parent.transform.parent.GetComponent<RoomManager>().Npc.GetComponent<NPCNeedManager>());
            GameObject objectToPlace = Inventory.Instance.item;
            GameObject currentObject =Instantiate(objectToPlace);
            currentObject.transform.position = new Vector3(0, 0, 0);
            currentObject.transform.SetParent(placingPosition, false);
            currentObject.GetComponent<BoxCollider>().enabled = true;
            currentObject.GetComponent<InteractablePlace>().infinite = false;
            currentObject.GetComponent<InteractablePlace>().needManager = this.transform.parent.transform.parent.transform.parent.GetComponent<RoomManager>().Npc.GetComponent<NPCNeedManager>();
            currentObject.GetComponent<InteractablePlace>().hasBeenPlacedDown = true;
             Inventory.Instance.RemoveItem();
            hasItem= true;
        }
    }
}
