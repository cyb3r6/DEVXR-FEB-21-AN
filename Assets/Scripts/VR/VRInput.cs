using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public Hands hand = Hands.Left;
    public float gripValue;

    /// <summary>
    /// The velocity of the controller
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// The angular velocity of the controller
    /// </summary>
    public Vector3 angularVelocity;

    private string gripAxis;


    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    void Start()
    { 
        gripAxis = $"{hand}Grip";
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);

        // controller velocity
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        angularVelocity = (transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = transform.eulerAngles; // transform.rotation = quaternion(x,y,z,w);

    }
}

[System.Serializable]
public enum Hands
{
    Left,
    Right
}
