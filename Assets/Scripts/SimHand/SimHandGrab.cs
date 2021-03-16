using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    /// <summary>
    /// What we're colliding with
    /// </summary>
    public GameObject collidingObject;

    /// <summary>
    /// What we're holding
    /// </summary>
    public GameObject heldObject;

    /// <summary>
    /// 
    /// </summary>
    public Transform snapPosition;

    /// <summary>
    /// How strong our throw is
    /// </summary>
    public float throwForce = 1f;

    private SimHandMove controller;



    private void Start()
    {
        controller = GetComponent<SimHandMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // save/caching what we're touching
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                // Grab!
                Grab();
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (heldObject)
            {
                Release();
            }
        }
    }

    public void Grab()
    {
        Debug.Log("Grabbing!");
        heldObject.transform.SetParent(snapPosition);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.simHandController = this;
            grabbable.isBeingHeld = true;
            heldObject.transform.localPosition += grabbable.grabOffset;
        }
    }

    public void Release()
    {
        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.isBeingHeld = false;
            grabbable.simHandController = null;
        }

        // throw
        Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        rb.velocity = controller.velocity * throwForce;
        rb.angularVelocity = controller.angularVelocity * throwForce;

        heldObject.transform.SetParent(null);
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject = null;
    }
}
