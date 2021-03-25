using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRContinuousMovement : MonoBehaviour
{
    public Transform xrRig;

    [Tooltip("Either the controller or the XR head")]
    public Transform director;

    private VRInput controller;
    private Vector3 playerForward;
    private Vector3 playerRight;

    void Awake()
    {
        controller = GetComponent<VRInput>();
    }


    void Update()
    {
        playerForward = director.forward;
        playerForward.y = 0;
        // make sure the forward value is always in the range of 0-1
        playerForward.Normalize();

        playerRight = director.right;
        playerRight.y = 0;
        // make sure the forward value is always in the range of 0-1
        playerRight.Normalize();

        // += operator!
        xrRig.position += playerForward * controller.thumbstick.y * Time.deltaTime;

        xrRig.position += playerRight * controller.thumbstick.x * Time.deltaTime;


    }
}
