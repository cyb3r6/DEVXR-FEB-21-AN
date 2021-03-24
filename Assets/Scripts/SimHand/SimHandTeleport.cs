using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandTeleport : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport")]
    public Transform xrRig;
    public bool shouldTeleport = false;
    private LineRenderer teleportLaser;
    private Vector3 hitPosition;

    
    void Awake()
    {
        teleportLaser = GetComponent<LineRenderer>();
        teleportLaser.enabled = false;
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            // start, direction, out RaycastHit
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Teleport!
                hitPosition = hit.point;
                teleportLaser.SetPosition(0, transform.position);
                teleportLaser.SetPosition(1, hitPosition);
                teleportLaser.enabled = true;

                shouldTeleport = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            if (shouldTeleport == true)
            {
                xrRig.transform.position = hitPosition;
                shouldTeleport = false;
                teleportLaser.enabled = false;
            }
        }
    }
}
