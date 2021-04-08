using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    // SimHand equivalent for controller triggers
    public UnityAction OnTriggerDown;
    public UnityAction OnTriggerUpdated;
    public UnityAction OnTriggerUp;

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

        if(Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            OnTriggerDown?.Invoke();
            
        }
        if (Input.GetKey(KeyCode.Mouse0) && heldObject)
        {
            OnTriggerUpdated?.Invoke();

        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && heldObject)
        {
            OnTriggerUp?.Invoke();
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

            OnTriggerDown += grabbable.OnInteractionStarted;
            OnTriggerUpdated += grabbable.OnInteractionStopped;
            OnTriggerUp += grabbable.OnInteractionStopped;
        }
    }

    public void Release()
    {
        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.isBeingHeld = false;
            grabbable.simHandController = null;

            OnTriggerDown -= grabbable.OnInteractionStarted;
            OnTriggerUpdated -= grabbable.OnInteractionStopped;
            OnTriggerUp -= grabbable.OnInteractionStopped;
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
