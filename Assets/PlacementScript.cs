using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementScript : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform placingPosition;
    private bool peterTheHorseIsHere = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && Inventory.Instance.item != null)
        {
            CanvasController.Instance.EnableInteractText();
            CanvasController.Instance.shouldRemove = false;
            peterTheHorseIsHere = true;
        }


    }
    private void OnTriggerStay(Collider other)
    {
        CanvasController.Instance.EnableInteractText();
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
            GameObject objectToPlace = Inventory.Instance.item;
            GameObject currentObject =Instantiate(objectToPlace);
            currentObject.transform.position = new Vector3(0, 0, 0);
            currentObject.transform.SetParent(placingPosition, false);
            currentObject.GetComponent<InteractablePlace>().infinite = false;
            Inventory.Instance.RemoveItem();
        }
    }
}
