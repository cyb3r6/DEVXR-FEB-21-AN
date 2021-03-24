using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class for grabbable objects
/// </summary>

public class GrabbableObjectVR : MonoBehaviour
{
    public VRInput controller;
    public bool isBeingHeld;
    public Vector3 grabOffset;

    // virtual void vs abstract void
    public virtual void OnInteraction() { }

}
