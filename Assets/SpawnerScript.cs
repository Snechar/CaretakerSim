using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject Pills;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
    // This implementation is very stupid and will add a lot of extra work in the future.
    // Enjoy dealing with it :)
    public void EnablePills()
    {
        Pills.SetActive(true);
        this.GetComponent<SphereCollider>().enabled = true;
    }
    public void DisablePills()
    {
        Pills.SetActive(false);
        this.GetComponent<SphereCollider>().enabled = false;
    }
}
