using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VRInput : MonoBehaviour
{
    public Hands hand = Hands.Left;
    public float gripValue;
    public float triggerValue;

    /// <summary>
    /// The velocity of the controller
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// The angular velocity of the controller
    /// </summary>
    public Vector3 angularVelocity;

    /// <summary>
    /// The direction of the joystick
    /// thumbstick
    /// </summary>
    public Vector2 thumbstick;

    private string gripAxis;
    private string triggerAxis;
    private string gripButton;
    private string triggerButton;
    private string thumbstickX;
    private string thumbstickY;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    public UnityAction OnGripDown;
    public UnityAction OnGripUpdated;
    public UnityAction OnGripUp;
    public UnityAction OnTriggerDown;
    public UnityAction OnTriggerUpdated;
    public UnityAction OnTriggerUp;

    void Start()
    { 
        gripAxis = $"{hand}Grip";
        triggerAxis = $"{hand}Trigger";
        gripButton = $"{hand}GripButton";
        triggerButton = $"{hand}TriggerButton";
        thumbstickX = $"{hand}ThumbstickX";
        thumbstickY = $"{hand}ThumbstickY";
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);
        thumbstick = new Vector2(Input.GetAxis(thumbstickX), Input.GetAxis(thumbstickY));

        if (Input.GetButtonDown(gripButton))
        {
            OnGripDown?.Invoke();
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
