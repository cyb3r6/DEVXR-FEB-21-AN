using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandMove : MonoBehaviour
{
    public Transform location;
    public Vector3 position;
    public float moveSpeed;
    public float turnSpeed;

    /// <summary>
    /// The velocity of the controller
    /// </summary>
    public Vector3 velocity;

    /// <summary>
    /// The angular velocity of the controller
    /// </summary>
    public Vector3 angularVelocity;

    private Vector3 previousPosition;
    private Vector3 previousAngularRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //location.position = position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }

        #region Rotation using Keyboard

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed,Space.World);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.C))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed, Space.Self);
        }

        #endregion

        #region Rotation using Mouse

        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * turnSpeed, Space.Self);

        #endregion

        // sprint?
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DoSprint(10);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DoSprint(0.1f);
        }

        // controller velocity
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
        angularVelocity = (transform.eulerAngles - previousAngularRotation) / Time.deltaTime;
        previousAngularRotation = transform.eulerAngles;

        // Lerp Example
        //transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);
    }

    public void DoSprint(float sprintFactor)
    {
        moveSpeed *= sprintFactor;      // 
        //moveSpeed = acceleration;  //Mathf.Lerp(moveSpeed, acceleration, Time.deltaTime);
    }
}
