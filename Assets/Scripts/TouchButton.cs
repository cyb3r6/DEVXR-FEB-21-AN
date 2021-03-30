using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour
{
    private Vector3 upPosition;
    public Transform downTransform;
    public Transform button;

    /// <summary>
    /// The thing to teleport
    /// </summary>
    [Tooltip("The thing to teleport")]
    public Transform teleportTransform;

    /// <summary>
    /// The location to teleport to
    /// </summary>
    [Tooltip("Where to teleport")]
    public Transform teleportPosition;

    void Start()
    {
        upPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.position = downTransform.position;
            teleportTransform.position = teleportPosition.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            button.position = upPosition;
        }
    }
}
