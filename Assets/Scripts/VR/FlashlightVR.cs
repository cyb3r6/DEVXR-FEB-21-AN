using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : GrabbableObjectVR
{
    public Light flashLight;

    public override void OnInteractionStarted()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
