using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightSimHand : GrabbableObjectSimHand
{
    public Light flashLight;

    //private GrabbableObjectSimHand grabbableObjectSimHand;
    
    void Start()
    {
        //grabbableObjectSimHand = GetComponent<GrabbableObjectSimHand>();
    }

    
    void Update()
    {
        if (isBeingHeld)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnInteractionStarted();
            }
            
        }
    }

    public override void OnInteractionStarted()
    {
        flashLight.enabled = !flashLight.enabled;
    }

}
