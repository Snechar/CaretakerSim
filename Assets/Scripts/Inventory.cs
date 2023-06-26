using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Transform parentTransform;
    public GameObject item = null;
    private GameObject ItemToCopy;


    public static Inventory Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    public void SetItem(GameObject Item)
    {
        if (item != null)
        {
            Destroy(item);
        }
        ItemToCopy = Item;
        item = Instantiate(ItemToCopy,parentTransform);
        item.GetComponent<BoxCollider>().enabled = false;
        item.transform.position = item.transform.parent.transform.position;
        CanvasController.Instance.EnableDropText();
    }
    public void RemoveItem()
    {
        if (item == null)
        {
            return;
        }
        Destroy(item);
        CanvasController.Instance.DisableDropText();
    }
}
