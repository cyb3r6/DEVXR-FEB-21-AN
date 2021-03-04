using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTriggerZone : MonoBehaviour
{
    public Animator bridgeAnimator;
    public float delay = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //bridgeAnimator.SetTrigger("Raise");
            bridgeAnimator.SetBool("IsRaising", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(TimedBridgeLower());
        }
    }

    private IEnumerator TimedBridgeLower()
    {

        yield return new WaitForSeconds(delay);
        bridgeAnimator.SetBool("IsRaising", false);
    }
}
