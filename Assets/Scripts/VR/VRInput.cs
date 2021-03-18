using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    private string triggerAxis;
    private string gripButton;
    private string triggerButton;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    public UnityEvent OnGripDown;
    public UnityEvent OnGripUpdated;
    public UnityEvent OnGripUp;
    public UnityEvent OnTriggerDown;
    public UnityEvent OnTriggerUpdated;
    public UnityEvent OnTriggerUp;

    void Start()
    { 
        gripAxis = $"{hand}Grip";
        triggerAxis = $"{hand}Trigger";
        gripButton = $"{hand}GripButton";
        triggerButton = $"{hand}TriggerButton";
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);

        if (Input.GetButtonDown(gripButton))
        {
            OnGripDown?.Invoke();
            Debug.Log("OnGripDown has been invoked");
        }
        if (Input.GetButton(gripButton))
        {
            OnGripUpdated?.Invoke();
        }
        if (Input.GetButtonUp(gripButton))
        {
            OnGripUp?.Invoke();
        }

        if (Input.GetButtonDown(triggerButton))
        {
            OnTriggerDown?.Invoke();
        }
        if (Input.GetButton(triggerButton))
        {
            OnTriggerUpdated?.Invoke();
        }
        if (Input.GetButtonUp(triggerButton))
        {
            OnTriggerUp?.Invoke();
        }

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
