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
                OnInteraction();
            }
            
        }
    }

    public override void OnInteraction()
    {
        flashLight.enabled = !flashLight.enabled;
    }

}
