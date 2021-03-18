using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : GrabbableObjectVR
{
    public Light flashLight;

    public override void OnInteraction()
    {
        flashLight.enabled = !flashLight.enabled;
    }
}
