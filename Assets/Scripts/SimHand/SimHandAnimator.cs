using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandAnimator : MonoBehaviour
{
    private Animator simHandAnimator;
    
    void Start()
    {
        simHandAnimator = GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            simHandAnimator.SetBool("IsClosing", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            simHandAnimator.SetBool("IsClosing", false);
        }
    }
}
