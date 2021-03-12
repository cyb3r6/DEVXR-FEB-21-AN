using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    // what we're touching
    public GameObject collidingObject;

    // what we're holding
    public GameObject heldObject;

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

    
    void Start()
    {
        
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
