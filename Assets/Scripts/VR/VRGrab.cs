using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    // what we're touching
    public GameObject collidingObject;

    // what we're holding
    public GameObject heldObject;

    private bool gripHeld;

    private VRInput controller;

    private void OnTriggerEnter(Collider other)
    {
        // save/caching what we're touching
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    
    void Awake()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {

        if (controller.gripValue > 0.5f && gripHeld == false)
        {
            gripHeld = true;
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                // Grab!
                Grab();
            }
        }
        if(controller.gripValue < 0.5f && gripHeld == true)
        {
            gripHeld = false;
            if (heldObject)
            {
                Release();
            }
        }

    }

    public void Grab()
    {
        Debug.Log("Grabbing!");
        heldObject.transform.SetParent(this.transform);

        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }
}
