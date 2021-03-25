using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRSnapTurn : MonoBehaviour
{
    public Transform xrRig;
    public int angle = 20;

    private VRInput controller;

    
    void Awake()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller.thumbstick.x > 0.9f)
        {
            xrRig.transform.Rotate(0, angle, 0, Space.World);
        }
        if(controller.thumbstick.x < -0.9f)
        {
            xrRig.transform.Rotate(0, -angle, 0, Space.World);
        }
    }
}
