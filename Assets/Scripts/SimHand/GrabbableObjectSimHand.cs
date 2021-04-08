using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base class for inheritance
/// </summary>

public class GrabbableObjectSimHand : MonoBehaviour
{
    public SimHandGrab simHandController;
    public bool isBeingHeld;
    public Vector3 grabOffset = new Vector3(0, 0, 0);

    public virtual void OnInteractionStarted() { }
    public virtual void OnInteractionUpdated() { }
    public virtual void OnInteractionStopped() { }
}
