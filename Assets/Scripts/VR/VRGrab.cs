﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    /// <summary>
    /// What we're touching
    /// </summary>
    public GameObject collidingObject;

    /// <summary>
    /// What we're holding
    /// </summary>
    public GameObject heldObject;

    /// <summary>
    /// How strong our throw is
    /// </summary>
    public float throwForce = 1f;

    public Transform snapPosition;

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

        controller.OnGripDown += Grab;
        controller.OnGripUp += Release;

    }
    void OnDisable()
    {
        controller.OnGripDown -= Grab;
        controller.OnGripUp -= Release;
    }

    #region using the Update
    /*
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
    */
    #endregion
    public void Grab()
    {
        if(collidingObject && collidingObject.GetComponent<Rigidbody>())
        {
            heldObject = collidingObject;

            heldObject.transform.SetParent(snapPosition);

            heldObject.transform.localPosition = Vector3.zero;
            heldObject.GetComponent<Rigidbody>().isKinematic = true;

            var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
            if (grabbable)
            {
                grabbable.controller = controller;
                grabbable.isBeingHeld = true;

                // heldObject.transform.localPosition = heldObject.transform.localPosition + grabbable.grabOffset
                heldObject.transform.localPosition += grabbable.grabOffset;

                // start listening for the trigger
                //controller.OnTriggerDown.AddListener(grabbable.OnInteraction);
                controller.OnTriggerDown += grabbable.OnInteractionStarted;
                controller.OnTriggerUpdated += grabbable.OnInteractionStopped;
                controller.OnTriggerUp += grabbable.OnInteractionStopped;
            }
        }
    }

    public void Release()
    {
        if (heldObject)
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
            if (grabbable)
            {
                grabbable.isBeingHeld = false;
                grabbable.controller = null;

                // stop listening for trigger
                //controller.OnTriggerDown.RemoveListener(grabbable.OnInteraction);
                controller.OnTriggerDown -= grabbable.OnInteractionStarted;
                controller.OnTriggerUpdated -= grabbable.OnInteractionStopped;
                controller.OnTriggerUp -= grabbable.OnInteractionStopped;
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
}
