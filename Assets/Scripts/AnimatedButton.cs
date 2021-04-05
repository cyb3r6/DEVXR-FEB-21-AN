using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedButton : MonoBehaviour
{
    public Animator buttonAnim;

    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");
            OnButtonPressed();
        }
    }
}
