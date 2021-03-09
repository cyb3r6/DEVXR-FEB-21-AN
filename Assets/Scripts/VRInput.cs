using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public Hands hand = Hands.Left;
    public float gripValue;


    private string gripAxis;
    


    void Start()
    {
        gripAxis = $"{hand}Grip";
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
    }
}

[System.Serializable]
public enum Hands
{
    Left,
    Right
}
