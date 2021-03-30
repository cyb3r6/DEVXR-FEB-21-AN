using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject shower;
    [Tooltip("The transform to follow for rain")]
    public Transform followTransform;

    private AnimatedButton button;
    private bool follow = false;
    
    void Start()
    {
        button = FindObjectOfType<AnimatedButton>();
        button.OnButtonPressed += DoRain;
    }

    void Update()
    {
        if(follow == true)
        {
            transform.position = followTransform.position;
        }
    }

    public void DoRain()
    {
        follow = !follow;
        shower.SetActive(follow);
    }
}
