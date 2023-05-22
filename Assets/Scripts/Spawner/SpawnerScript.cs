using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Pills;
    public GameObject PillDispenser;
    public SpawnerController Controller;
    public BaseObject CurrentObject;

    // This implementation is very stupid and will add a lot of extra work in the future.
    // Enjoy dealing with it :)
    public void EnablePills()
    {
        Pills.SetActive(true);
        this.GetComponent<SphereCollider>().enabled = true;
        CurrentObject = PillDispenser.GetComponent<PillsObject>();
    }
    public void DisablePills()
    {
        Pills.SetActive(false);
        this.GetComponent<SphereCollider>().enabled = false;
        CurrentObject = null;
    }
    public void EnablePillDispenser()
    {
        PillDispenser.SetActive(true);
        this.GetComponent<SphereCollider>().enabled = true;


    }
    public void DisablePillDispenser()
    {
        PillDispenser.SetActive(false);
        this.GetComponent<SphereCollider>().enabled = false;
        CurrentObject = null;

    }

    public void Interact()
    {
        if (CurrentObject != null)
        {
            CurrentObject.OnUse(this);
        }
    }
}
